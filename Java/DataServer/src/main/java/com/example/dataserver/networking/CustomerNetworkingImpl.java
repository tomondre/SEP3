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
import org.springframework.beans.factory.annotation.Autowired;

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
    public void createCustomer(CustomerMessage request, StreamObserver<CustomerMessage> responseObserver) {

        var customer = new Customer(request);
        var user = customer.getUser();
        user.setCustomer(customer);

        System.out.println(dao.createCustomer(user));

        //        responseObserver.onNext(UserMessage.newBuilder().setMassageOrObject(s).build());
//        responseObserver.onCompleted();
    }
}
