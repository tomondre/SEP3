package com.example.dataserver.networking;

import com.example.dataserver.persistence.ProviderDAO;
import com.example.dataserver.models.Provider;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.provider.ProtobufMessage;
import networking.provider.ProtobufProviderServiceGrpc;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;

import java.util.ArrayList;

@GrpcService
public class ProviderNeworkingImpl extends ProtobufProviderServiceGrpc.ProtobufProviderServiceImplBase {

    private ProviderDAO model;
    private Gson gson;

    @Autowired
    public ProviderNeworkingImpl(ProviderDAO model) {
        this.model = model;
        gson = new Gson();
    }

    @Async
    @Override
    public void createProvider(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        Provider provider = gson.fromJson(request.getMassageOrObject(), Provider.class);
        model.createProvider(provider);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getAllProviders(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        ArrayList<Provider> allProviders = model.getAllProviders();
        String s = gson.toJson(allProviders);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(s).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getProviderById(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        Provider providerById = model.getProviderById(Integer.parseInt(request.getMassageOrObject()));
        String providerJson = gson.toJson(providerById);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(providerJson).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void editProvider(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        Provider provider = gson.fromJson(request.getMassageOrObject(), Provider.class);
        model.editProvider(provider);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void removeProvider(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        model.removeProvider(Integer.parseInt(request.getMassageOrObject()));
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
        responseObserver.onCompleted();
    }

    @Override
    public void getAllNotApprovedProviders(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        ArrayList<Provider> allNotApprovedProviders = model.getAllNotApprovedProviders();
        String json = gson.toJson(allNotApprovedProviders);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(json).build());
        responseObserver.onCompleted();
    }
}