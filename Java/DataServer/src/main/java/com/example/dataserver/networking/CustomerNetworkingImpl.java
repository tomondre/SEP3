package com.example.dataserver.networking;

import com.example.dataserver.models.Address;
import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.customer.CustomerDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.customer.CustomerMessage;
import networking.customer.CustomerServiceGrpc;
import networking.customer.CustomersMessage;
import networking.page.PageMessage;
import networking.request.PageRequestMessage;
import networking.request.RequestMessage;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.scheduling.annotation.Async;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

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
    public void getAllCustomers(PageRequestMessage request,
                                StreamObserver<CustomersMessage> responseObserver)
    {
        var pageRequest = PageRequest.of(request.getPageNumber(), request.getPageSize());
        var page = dao.getAllCustomers(pageRequest);
        customers(responseObserver, page);
    }

    @Override
    public void deleteCustomer(UserMessage request,
        StreamObserver<CustomerMessage> responseObserver)
    {
        dao.deleteCustomer(request.getId());
        responseObserver.onNext(CustomerMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getCustomerById(UserMessage request, StreamObserver<CustomerMessage> responseObserver) {
        var customerById = dao.getCustomerById(request.getId());
        var customerMessage = customerById.toCustomerMessage();
        responseObserver.onNext(customerMessage);
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void editCustomer(CustomerMessage request, StreamObserver<CustomerMessage> responseObserver) {
        Customer customer = new Customer(request);
        User user = customer.getUser();
        user.setCustomer(customer);
        User edited = dao.editCustomer(user);
        CustomerMessage customerMessage = edited.toCustomerMessage();
        responseObserver.onNext(customerMessage);
        responseObserver.onCompleted();

    }

    @Override
    public void findCustomerByName(RequestMessage request, StreamObserver<CustomersMessage> responseObserver)
    {
        var name = request.getName();
        var pageRequest = PageRequest.of(request.getPageInfo().getPageNumber(), request.getPageInfo().getPageSize());
        var page = dao.findCustomerByName(name, pageRequest);
        customers(responseObserver, page);
    }

    private void customers(StreamObserver<CustomersMessage> responseObserver, Page<User> page)
    {
        var collect = page.getContent().stream().map(User::toCustomerMessage)
                          .collect(Collectors.toList());
        PageMessage pageInfo = PageMessage.newBuilder().setPageNumber(page.getNumber()).setTotalPages(page.getTotalPages())
                                          .setTotalElements(page.getTotalPages()).build();
        CustomersMessage customersMessage = CustomersMessage.newBuilder().addAllCustomers(collect).setPage(pageInfo).build();
        responseObserver.onNext(customersMessage);
        responseObserver.onCompleted();
    }
}
