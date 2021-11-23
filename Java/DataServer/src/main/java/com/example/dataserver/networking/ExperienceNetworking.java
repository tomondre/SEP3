package com.example.dataserver.networking;

import com.example.dataserver.models.Experience;
import com.example.dataserver.persistence.experience.ExperienceDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.experience.ProtobufMessage;
import networking.experience.ProtobufStockRequest;
import org.springframework.beans.factory.annotation.Autowired;
import networking.experience.ExperienceServiceGrpc;

import java.util.ArrayList;

@GrpcService
public class ExperienceNetworking extends ExperienceServiceGrpc.ExperienceServiceImplBase
{
  private ExperienceDAO experienceDAO;
  private Gson gson;

  @Autowired
  public ExperienceNetworking(ExperienceDAO experienceDAO)
  {
    this.experienceDAO = experienceDAO;
    gson = new Gson();
  }

  @Override
  public void getAllProviderExperiences(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    ArrayList<Experience> allProviderExperiences = experienceDAO.getAllProviderExperiences(
    Integer.parseInt(request.getMessageOrObject()));
    String toJson = gson.toJson(allProviderExperiences);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(toJson).build());
    responseObserver.onCompleted();
  }

  @Override
  public void getAllWebShopExperiences(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    ArrayList<Experience> allWebShopExperiences = experienceDAO.getAllWebShopExperiences();
    String s = gson.toJson(allWebShopExperiences);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(s).build());
    responseObserver.onCompleted();
  }

  @Override
  public void addExperience(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    Experience experience = gson.fromJson(request.getMessageOrObject(),Experience.class);
    Experience result =  experienceDAO.addExperience(experience);
    String string =  gson.toJson(result);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(string).build());
    responseObserver.onCompleted();
  }

  @Override
  public void getExperienceById(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
    int id = Integer.parseInt(request.getMessageOrObject());
    Experience experienceById = experienceDAO.getExperienceById(id);
    String json = gson.toJson(experienceById);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(json).build());
    responseObserver.onCompleted();
  }
  @Override
  public void isInStock(ProtobufStockRequest request, StreamObserver<ProtobufMessage> responseObserver)
  {
    int id = request.getId();
    int quantity = request.getQuantity();
    boolean inStock = experienceDAO.isInStock(id, quantity);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(String.valueOf(inStock) ).build());
    responseObserver.onCompleted();
  }

  @Override
  public void removeStock(ProtobufStockRequest request, StreamObserver<ProtobufMessage> responseObserver) {
    experienceDAO.removeStock(request.getId(), request.getQuantity());
  }
}
