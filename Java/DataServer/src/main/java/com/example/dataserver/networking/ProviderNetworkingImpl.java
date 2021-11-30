package com.example.dataserver.networking;

import com.example.dataserver.models.Provider;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.provider.ProviderDAO;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.provider.ProviderMessage;
import networking.provider.ProviderServiceGrpc;
import networking.provider.ProvidersMessage;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;

import java.util.ArrayList;
import java.util.stream.Collectors;

@GrpcService
public class ProviderNetworkingImpl extends ProviderServiceGrpc.ProviderServiceImplBase
{

  private ProviderDAO model;

  @Autowired
  public ProviderNetworkingImpl(ProviderDAO model)
  {
    this.model = model;
  }

  @Async
  @Override
  public void createProvider(ProviderMessage request, StreamObserver<UserMessage> responseObserver)
  {
    var provider = new Provider(request);
    var user = provider.getUser();
    user.setProvider(provider);
    User providerCreated = model.createProvider(user);

    UserMessage userMessage = providerCreated.toMessage();
    responseObserver.onNext(userMessage);
    responseObserver.onCompleted();
  }

  @Async
  @Override
  public void getAllProviders(ProviderMessage request,
      StreamObserver<ProvidersMessage> responseObserver)
  {
    ArrayList<User> allProviders = model.getAllProviders();
    var collect = allProviders.stream().map(User::toProviderMessage).collect(Collectors.toList());
    ProvidersMessage providersMessage = ProvidersMessage.newBuilder().addAllProviders(collect)
        .build();
    responseObserver.onNext(providersMessage);
    responseObserver.onCompleted();
  }

  @Async
  @Override
  public void getProviderById(UserMessage request, StreamObserver<ProviderMessage> responseObserver)
  {
    var providerById = model.getProviderById(request.getId());
    var provider = providerById.toProviderMessage();
    responseObserver.onNext(provider);
    responseObserver.onCompleted();
  }

  @Async
  @Override
  public void editProvider(ProviderMessage request,
      StreamObserver<ProviderMessage> responseObserver)
  {
    User user = model.editProvider(new User(request));
    ProviderMessage providerMessage = user.toProviderMessage();
    responseObserver.onNext(providerMessage);
    responseObserver.onCompleted();
  }

  @Async
  @Override
  public void removeProvider(UserMessage request, StreamObserver<ProviderMessage> responseObserver)
  {
    model.removeProvider(request.getId());
    responseObserver.onNext(ProviderMessage.newBuilder().build());
    responseObserver.onCompleted();
  }

  @Override
  public void getAllNotApprovedProviders(ProviderMessage request,
      StreamObserver<ProvidersMessage> responseObserver)
  {
    var allNotApprovedProviders = model.getAllNotApprovedProviders();
    var collect = allNotApprovedProviders.stream().map(User::toProviderMessage)
        .collect(Collectors.toList());
    var providersMessage = ProvidersMessage.newBuilder().addAllProviders(collect).build();
    responseObserver.onNext(providersMessage);
    responseObserver.onCompleted();
  }
}