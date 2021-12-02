package com.example.dataserver.networking;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.customer.CustomerDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.customer.CustomerMessage;
import networking.customer.CustomerServiceGrpc;
import networking.customer.CustomersMessage;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@GrpcService
public class CustomerNetworkingImpl extends CustomerServiceGrpc.CustomerServiceImplBase {

    private Gson gson;
    private CustomerDAO dao;
    @Autowired
    public CustomerNetworkingImpl(CustomerDAO dao) {
        this.dao = dao;
        gson = new Gson();
    }

    @Override
    public void createCustomer(CustomerMessage request, StreamObserver<UserMessage> responseObserver) {

        var customer = new Customer(request);
        var user = customer.getUser();
        user.setCustomer(customer);

        User createdCustomer = dao.createCustomer(user);
        UserMessage userMessage = createdCustomer.toMessage();
        responseObserver.onNext(userMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllCustomers(UserMessage request,
        StreamObserver<CustomersMessage> responseObserver)
    {
        ArrayList<User> allCustomers = dao.getAllCustomers();
        List<CustomerMessage> collect = allCustomers.stream().map(User::toCustomerMessage)
            .collect(Collectors.toList());
        CustomersMessage customersMessage = CustomersMessage.newBuilder().addAllCustomers(collect).build();
        responseObserver.onNext(customersMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void deleteCustomer(UserMessage request,
        StreamObserver<CustomerMessage> responseObserver)
    {
        dao.deleteCustomer(request.getId());
        responseObserver.onNext(CustomerMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    @Override
    public void findCustomerByName(UserMessage request, StreamObserver<CustomersMessage> responseObserver)
    {
        ArrayList<User> customerByName = dao.findCustomerByName(request.getEmail());
        List<CustomerMessage> collect =
                customerByName.stream().map(User::toCustomerMessage).collect(Collectors.toList());
        CustomersMessage builder = CustomersMessage.newBuilder().addAllCustomers(collect).build();
        responseObserver.onNext(builder);
        responseObserver.onCompleted();
    }
}
