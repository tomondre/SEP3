package com.example.dataserver.networking;

import com.example.dataserver.models.Customer;
import com.example.dataserver.persistence.customer.CustomerDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.customers.CustomerServiceGrpc;
import networking.customers.ProtobufMessage;
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
    public void createCustomer(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        Customer customer = gson.fromJson(request.getMassageOrObject(), Customer.class);
        Customer result = dao.createCustomer(customer);
        String s = gson.toJson(result);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(s).build());
        responseObserver.onCompleted();
    }
}
