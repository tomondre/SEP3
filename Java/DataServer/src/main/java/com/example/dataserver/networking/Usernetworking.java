package com.example.dataserver.networking;

import com.example.dataserver.persistence.provider.ProviderDAO;
import com.example.dataserver.persistence.user.UserDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.user.ProtobufMessage;
import networking.user.UserServiceGrpc;
import org.springframework.beans.factory.annotation.Autowired;

@GrpcService
public class Usernetworking extends UserServiceGrpc.UserServiceImplBase
{
  private UserDAO model;
  private Gson gson;

  @Autowired
  public Usernetworking(UserDAO model) {
    this.model = model;
    gson = new Gson();
  }

  @Override
  public void createUser(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
  {
    model.addProvider(null);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject("Success").build());
    responseObserver.onCompleted();
  }
}
