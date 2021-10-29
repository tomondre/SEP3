package com.example.dataserver.networking;

import com.example.dataserver.model.ProviderModel;
import com.example.dataserver.shared.Provider;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;

import java.util.ArrayList;

@GrpcService
public class ProviderNeworkingImpl extends ProtobufProviderServiceGrpc.ProtobufProviderServiceImplBase {

    private ProviderModel model;

    @Autowired
    public ProviderNeworkingImpl(ProviderModel model) {
        this.model = model;
    }

    @Async
    @Override
    public void createProvider(ProtobufProvider request, StreamObserver<ProtobufResponse> responseObserver) {
        model.createProvider(new Provider(request));
        responseObserver.onNext(ProtobufResponse.newBuilder().setMessage("Success").build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getAllProviders(ProtobufRequest request, StreamObserver<ProtobufProviderList> responseObserver) {
        ArrayList<Provider> allProviders = model.getAllProviders();
        ProtobufProviderList.Builder protobufProviderList = ProtobufProviderList.newBuilder();
        for (Provider provider : allProviders) {
            protobufProviderList.addValue(provider.toProtobuf());
        }
        responseObserver.onNext(protobufProviderList.build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getProviderById(GetProviderByIdRequest request, StreamObserver<ProtobufProvider> responseObserver) {
        Provider providerById = model.getProviderById(request.getId());
        responseObserver.onNext(providerById.toProtobuf());
        responseObserver.onCompleted();
    }
}
