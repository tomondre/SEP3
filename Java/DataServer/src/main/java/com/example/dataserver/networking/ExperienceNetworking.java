package com.example.dataserver.networking;

import com.example.dataserver.models.Experience;
import com.example.dataserver.persistence.experience.ExperienceDAO;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.experience.ExperienceListMessage;
import networking.experience.ExperienceMessage;
import networking.experience.ExperienceServiceGrpc;
import networking.request.RequestMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;

import java.util.ArrayList;
import java.util.List;

@GrpcService
@EnableAsync
public class ExperienceNetworking extends ExperienceServiceGrpc.ExperienceServiceImplBase
{
    private ExperienceDAO experienceDAO;

    @Autowired
    public ExperienceNetworking(ExperienceDAO experienceDAO)
    {
        this.experienceDAO = experienceDAO;
    }

//    @Async
    @Override
    public void getAllProviderExperiences(RequestMessage request,
                                          StreamObserver<ExperienceListMessage> responseObserver)
    {
        ArrayList<Experience> allProviderExperiences = experienceDAO.getAllProviderExperiences(request.getId());
        responseObserver.onNext(arrayListToListMessage(allProviderExperiences));
        responseObserver.onCompleted();
    }

//    @Async
    @Override
    public void getAllWebShopExperiences(RequestMessage request, StreamObserver<ExperienceListMessage> responseObserver)
    {
        ArrayList<Experience> allWebShopExperiences = experienceDAO.getAllWebShopExperiences();
        responseObserver.onNext(arrayListToListMessage(allWebShopExperiences));
        responseObserver.onCompleted();
    }

//    @Async
    @Override
    public void addExperience(ExperienceMessage request, StreamObserver<ExperienceMessage> responseObserver)
    {
        Experience experience = experienceDAO.addExperience(new Experience(request));
        responseObserver.onNext(experience.toMessage());
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void getExperienceById(RequestMessage request, StreamObserver<ExperienceMessage> responseObserver)
    {
        Experience experienceById = experienceDAO.getExperienceById(request.getId());
        responseObserver.onNext(experienceById.toMessage());
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void isInStock(RequestMessage request, StreamObserver<RequestMessage> responseObserver)
    {
        boolean inStock = experienceDAO.isInStock(request.getId(), request.getQuantity());
        responseObserver.onNext(RequestMessage.newBuilder().setResponse(inStock).build());
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void deleteExperience(RequestMessage request, StreamObserver<RequestMessage> responseObserver)
    {
        experienceDAO.deleteExperience(request.getId());
        responseObserver.onNext(RequestMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void removeStock(RequestMessage request, StreamObserver<RequestMessage> responseObserver)
    {
        experienceDAO.removeStock(request.getId(), request.getQuantity());
        responseObserver.onNext(RequestMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void getExperienceByCategory(RequestMessage request, StreamObserver<ExperienceListMessage> responseObserver)
    {
        var experienceByCategory = experienceDAO.getExperienceByCategory(request.getId());
        responseObserver.onNext(arrayListToListMessage(experienceByCategory));
        responseObserver.onCompleted();
    }

    // @Async
    @Override
    public void getTopExperiences(RequestMessage request, StreamObserver<ExperienceListMessage> responseObserver)
    {
        ArrayList<Experience> topExperiences = experienceDAO.getTopExperiences();
        responseObserver.onNext(arrayListToListMessage(topExperiences));
        responseObserver.onCompleted();
    }

// @Async
    @Override
    public void getAllProviderExperiencesByName(RequestMessage request,
                                                StreamObserver<ExperienceListMessage> responseObserver)
    {
        ArrayList<Experience> allProviderExperiencesByName =
                experienceDAO.getAllProviderExperiencesByName(request.getId(), request.getName());
        responseObserver.onNext(arrayListToListMessage(allProviderExperiencesByName));
        responseObserver.onCompleted();
    }

  @Override
  public void getSortedExperiences(RequestMessage request, StreamObserver<ExperienceListMessage> responseObserver) {

    ArrayList<Experience> sortedExperiences = experienceDAO.getSortedExperiences(request.getName(), request.getPrice());
    responseObserver.onNext(arrayListToListMessage(sortedExperiences));
    responseObserver.onCompleted();
  }

    private ExperienceListMessage arrayListToListMessage(List<Experience> experiences)
    {
        ExperienceListMessage.Builder builder = ExperienceListMessage.newBuilder();
        for (Experience e : experiences)
        {
            builder.addExperiences(e.toMessage());
        }
        return builder.build();
    }
}