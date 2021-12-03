package com.example.dataserver.networking;

import com.example.dataserver.models.Category;
import com.example.dataserver.persistence.category.CategoryDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.category.CategoriesMessage;
import networking.category.CategoryMessage;
import networking.category.CategoryServiceGrpc;
import networking.page.PageMessage;
import networking.request.PageRequestMessage;
import networking.request.RequestMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;

import java.util.stream.Collectors;

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
    public void getAllProductCategories(PageRequestMessage request, StreamObserver<CategoriesMessage> responseObserver)
    {
        PageRequest pageRequest = PageRequest.of(request.getPageNumber(), request.getPageSize());
        var allCategories = categoryDAO.getAllCategories(pageRequest);
        var collect = allCategories.getContent().stream().map(Category::toMessage).collect(Collectors.toList());
        PageMessage pageMessage = PageMessage.newBuilder().setTotalElements(allCategories.getTotalElements())
                                             .setTotalPages(allCategories.getTotalPages())
                                             .setPageNumber(allCategories.getNumber()).build();
        CategoriesMessage categoriesMessage =
                CategoriesMessage.newBuilder().addAllCategories(collect).setPageInfo(pageMessage).build();
        responseObserver.onNext(categoriesMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void addProductCategory(CategoryMessage request, StreamObserver<CategoryMessage> responseObserver)
    {
        Category category = new Category(request);
        Category createdCategory = categoryDAO.addProductCategory(category);
        CategoryMessage categoryMessage = createdCategory.toMessage();
        responseObserver.onNext(categoryMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void editProductCategory(CategoryMessage request, StreamObserver<CategoryMessage> responseObserver)
    {
        Category category = new Category(request);
        Category editedCategory = categoryDAO.editProductCategory(category);
        CategoryMessage categoryMessage = editedCategory.toMessage();
        responseObserver.onNext(categoryMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void deleteProductCategory(RequestMessage request, StreamObserver<CategoryMessage> responseObserver)
    {
        categoryDAO.deleteProductCategory(request.getId());
        responseObserver.onNext(CategoryMessage.newBuilder().build());
        responseObserver.onCompleted();
    }
}
