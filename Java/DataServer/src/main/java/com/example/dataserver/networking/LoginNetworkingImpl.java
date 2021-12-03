package com.example.dataserver.networking;

import com.example.dataserver.models.User;
import com.example.dataserver.persistence.customer.CustomerDAO;
import com.example.dataserver.persistence.login.LoginDAO;
import com.example.dataserver.persistence.provider.ProviderDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.login.LoginServiceGrpc;
import networking.login.ProtobufMessage;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;

@GrpcService
public class LoginNetworkingImpl extends LoginServiceGrpc.LoginServiceImplBase
{
  private LoginDAO loginDAO;
  private Gson gson;

  @Autowired
  public LoginNetworkingImpl(LoginDAO loginDAO)
  {
    this.loginDAO = loginDAO;
    gson = new Gson();
  }

  @Override
  public void getUserLogin(UserMessage request,
      StreamObserver<UserMessage> responseObserver)
  {
    User userLogin = loginDAO.getUserLogin(new User(request));
    UserMessage userMessage = userLogin.toMessage();
    responseObserver.onNext(userMessage);
    responseObserver.onCompleted();
  }
}
