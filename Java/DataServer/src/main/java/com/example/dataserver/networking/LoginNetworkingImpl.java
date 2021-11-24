package com.example.dataserver.networking;

import com.example.dataserver.models.Administrator;
import com.example.dataserver.models.Customer;
import com.example.dataserver.models.Provider;
import com.example.dataserver.persistence.administrator.AdministratorDAO;
import com.example.dataserver.persistence.customer.CustomerDAO;
import com.example.dataserver.persistence.provider.ProviderDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.login.LoginServiceGrpc;
import networking.login.ProtobufMessage;

@GrpcService
public class LoginNetworkingImpl extends LoginServiceGrpc.LoginServiceImplBase
{
  private AdministratorDAO administratorDAO;
  private ProviderDAO providerDAO;
  private CustomerDAO customerDAO;
  private Gson gson;

  public LoginNetworkingImpl(AdministratorDAO administratorDAO, ProviderDAO providerDAO,
      CustomerDAO customerDAO)
  {
    this.administratorDAO = administratorDAO;
    this.providerDAO = providerDAO;
    this.customerDAO = customerDAO;
    gson = new Gson();
  }

  @Override
  public void getProviderLogin(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {

  }

  @Override
  public void getCustomerLogin(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
  }

  @Override
  public void addAdministratorLogin(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    Administrator administratorByEmail = administratorDAO.getAdministratorByEmail(
        request.getMessageOrObject());
    String s = gson.toJson(administratorByEmail);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(s).build());
    responseObserver.onCompleted();
  }
}
