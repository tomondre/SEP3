package com.example.dataserver.networking;

import com.example.dataserver.persistence.provider.ProviderDAO;
import com.example.dataserver.models.Provider;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.provider.ProviderMessage;
import networking.provider.ProviderServiceGrpc;
import org.aspectj.apache.bcel.classfile.Module;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;

import java.util.ArrayList;

@GrpcService
public class ProviderNeworkingImpl extends ProviderServiceGrpc.ProviderServiceImplBase {

    private ProviderDAO model;
    private Gson gson;

    @Autowired
    public ProviderNeworkingImpl(ProviderDAO model) {
        this.model = model;
        gson = new Gson();
    }

    @Async
    @Override
    public void createProvider(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
        var provider = new Provider(request);
        var user = provider.getUser();
        user.setProvider(provider);

        model.createProvider(user);
//        Provider provider = gson.fromJson(request.getMassageOrObject(), Provider.class);
//        model.createProvider(provider);
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
//        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getAllProviders(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
//        ArrayList<Provider> allProviders = model.getAllBy();
//        String s = gson.toJson(allProviders);
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(s).build());
//        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getProviderById(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
//        Provider providerById = model.getProviderById(Integer.parseInt(request.getMassageOrObject()));
//        String providerJson = gson.toJson(providerById);
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(providerJson).build());
//        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void editProvider(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
//        Provider provider = gson.fromJson(request.getMassageOrObject(), Provider.class);
//        model.editProvider(provider);
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
//        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void removeProvider(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
//        model.removeProvider(Integer.parseInt(request.getMassageOrObject()));
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
//        responseObserver.onCompleted();
    }

    @Override
    public void getAllNotApprovedProviders(ProviderMessage request, StreamObserver<ProviderMessage> responseObserver) {
//        ArrayList<Provider> allNotApprovedProviders = model.getAllNotApprovedProviders();
//        String json = gson.toJson(allNotApprovedProviders);
//        responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(json).build());
//        responseObserver.onCompleted();
    }
}