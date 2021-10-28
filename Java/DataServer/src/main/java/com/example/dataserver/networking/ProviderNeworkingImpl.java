package com.example.dataserver.networking;

import com.example.dataserver.model.ProviderModel;
import com.example.dataserver.shared.Address;
import com.example.dataserver.shared.Provider;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;

@GrpcService
public class ProviderNeworkingImpl extends ProviderServiceGrpc.ProviderServiceImplBase {

    private ProviderModel model;

    @Autowired
    public ProviderNeworkingImpl(ProviderModel model)
    {
        this.model = model;
    }

    @Override
    public void getAllProviders(Request request, StreamObserver<ProviderList> responseObserver) {

        ProviderList.Builder builder = ProviderList.newBuilder();
        for (Provider provider : model.getAllProviders()) {
            try {
                com.example.dataserver.networking.Provider.Builder bld = com.example.dataserver.networking.Provider.newBuilder()
                        .setCompanyName(provider.getCompanyName())
                        .setCvr(provider.getCVR())
                        .setPhoneNumber(provider.getPhoneNumber())
                        .setDescription(provider.getDescription())
                        .setStreet(provider.getAddress().getStreet())
                        .setCity(provider.getAddress().getCity())
                        .setStreetNumber(provider.getAddress().getStreetNumber())
                        .setPostCode(provider.getAddress().getPostCode());
                builder.addValue(bld);
            }
            catch (Exception e)
            {}
        }
        responseObserver.onNext(builder.build());
        responseObserver.onCompleted();
    }

    @Override
    public void createProvider(com.example.dataserver.networking.Provider request, StreamObserver<SuccessResponse> responseObserver) {
        Address address = new Address(request.getStreet(), request.getStreetNumber(), request.getPostCode(), request.getCity());
        Provider provider = new Provider(request.getCompanyName(),request.getCvr(),request.getPhoneNumber(), request.getDescription(), address);
        model.createProvider(provider);
    }
}
