package com.example.dataserver.networking;

import com.example.dataserver.models.Experience;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.experience.ExperienceDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.experience.ExperienceServiceGrpc;
import networking.experience.ProtobufMessage;
import networking.experience.ProtobufStockRequest;
import networking.page.PageMessage;
import networking.provider.ProvidersMessage;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.stream.Collectors;

@GrpcService
@EnableAsync
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

    @Async
    @Override
    public void getAllProviderExperiences(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        ArrayList<Experience> allProviderExperiences =
                experienceDAO.getAllProviderExperiences(Integer.parseInt(request.getMessageOrObject()));
        String toJson = gson.toJson(allProviderExperiences);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(toJson).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getAllWebShopExperiences(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        ArrayList<Experience> allWebShopExperiences = experienceDAO.getAllWebShopExperiences();
        String s = gson.toJson(allWebShopExperiences);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(s).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void addExperience(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        Experience experience = gson.fromJson(request.getMessageOrObject(), Experience.class);
        Experience result = experienceDAO.addExperience(experience);
        String string = gson.toJson(result);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(string).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getExperienceById(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        int id = Integer.parseInt(request.getMessageOrObject());
        Experience experienceById = experienceDAO.getExperienceById(id);
        String json = gson.toJson(experienceById);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(json).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void isInStock(ProtobufStockRequest request, StreamObserver<ProtobufMessage> responseObserver)
    {
        int id = request.getId();
        int quantity = request.getQuantity();
        boolean inStock = experienceDAO.isInStock(id, quantity);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(String.valueOf(inStock)).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void deleteExperience(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        int experienceId = Integer.parseInt(request.getMessageOrObject());
        experienceDAO.deleteExperience(experienceId);
        responseObserver.onNext(ProtobufMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void removeStock(ProtobufStockRequest request, StreamObserver<ProtobufMessage> responseObserver)
    {
        experienceDAO.removeStock(request.getId(), request.getQuantity());
        responseObserver.onNext(ProtobufMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getAllProviderExperiencesByName(UserMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        ArrayList<Experience> allProviderExperiencesByName =
                experienceDAO.getAllProviderExperiencesByName(request.getId(), request.getEmail());
        String s = gson.toJson(allProviderExperiencesByName);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(s).build());
        responseObserver.onCompleted();
    }

    @Async
    @Override
    public void getExperienceByCategory(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver)
    {
        List<Experience> experienceByCategory =
                experienceDAO.getExperienceByCategory(Integer.parseInt(request.getMessageOrObject()), 0);
        String s = gson.toJson(experienceByCategory);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(s).build());
        responseObserver.onCompleted();
    }

    private synchronized void customers(StreamObserver<ProvidersMessage> responseObserver, Future<Page<User>> pageFuture)
    {
        Page<User> page = getObjectAfterDone(pageFuture);
        var collect = page.getContent().stream().map(User::toProviderMessage)
                          .collect(Collectors.toList());
        PageMessage pageInfo = PageMessage.newBuilder().setPageNumber(page.getNumber()).setTotalPages(page.getTotalPages())
                                          .setTotalElements(page.getTotalPages()).build();
        var providersMessage = ProvidersMessage.newBuilder().addAllProviders(collect).setPageInfo(pageInfo).build();
        responseObserver.onNext(providersMessage);
        responseObserver.onCompleted();
    }

    private synchronized  <T> T getObjectAfterDone(Future<T> future)
    {
        T object;
        while (true)
        {
            if (future.isDone())
            {
                try
                {
                    object = future.get();
                    break;
                }
                catch (ExecutionException | InterruptedException e)
                {
                    e.printStackTrace();
                }
            }
        }
        return object;
    }
}
