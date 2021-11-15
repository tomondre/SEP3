package com.example.dataserver.networking;

import com.example.dataserver.models.Category;
import com.example.dataserver.persistence.category.CategoryDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.category.CategoryServiceGrpc;
import networking.category.ProtobufMessage;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.ArrayList;

@GrpcService
public class ProductCategoryNetworkingImpl extends CategoryServiceGrpc.CategoryServiceImplBase
{
  private CategoryDAO categoryDAO;
  private Gson gson;

  @Autowired
  public ProductCategoryNetworkingImpl(CategoryDAO categoryDAO)
  {
    this.categoryDAO = categoryDAO;
    gson = new Gson();
  }

  @Override
  public void getAllProductCategories(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    ArrayList<Category> allCategories = categoryDAO.getAllCategories();
    String json = gson.toJson(allCategories);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(json).build());
    responseObserver.onCompleted();
  }

  @Override
  public void addProductCategory(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    var category = gson.fromJson(request.getMassageOrObject(), Category.class);
    Category categoryCreated = categoryDAO.addProductCategory(category);
    String json = gson.toJson(categoryCreated);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(json).build());
    responseObserver.onCompleted();
  }

  @Override
  public void editProductCategory(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    Category category = gson.fromJson(request.getMassageOrObject(), Category.class);
    Category categoryEdited = categoryDAO.editProductCategory(category);
    String json = gson.toJson(categoryEdited);
    responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject(json).build());
  }

  @Override
  public void deleteProductCategory(ProtobufMessage request,
      StreamObserver<ProtobufMessage> responseObserver)
  {
    categoryDAO.deleteProductCategory(Integer.parseInt(request.getMassageOrObject()));
    responseObserver.onNext(ProtobufMessage.newBuilder().setMassageOrObject("Success").build());
    responseObserver.onCompleted();
  }
}
