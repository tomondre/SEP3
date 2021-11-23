package com.example.dataserver.networking;

import com.example.dataserver.persistence.order.OrderDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.order.OrderServiceGrpc;
import networking.order.ProtobufMessage;
import org.springframework.beans.factory.annotation.Autowired;

@GrpcService
public class OrderNetworking extends OrderServiceGrpc.OrderServiceImplBase {

    private OrderDAO orderDAO;
    private Gson gson;

    @Autowired
    public OrderNetworking(OrderDAO orderDAO) {
        this.orderDAO = orderDAO;
        gson = new Gson();
    }

    @Override
    public void createOrder(ProtobufMessage request, StreamObserver<ProtobufMessage> responseObserver) {
        Order order = gson.fromJson(request.getMessageOrObject(), Order.class);
        Order result = orderDAO.createOrder(order);
        responseObserver.onNext(ProtobufMessage.newBuilder().setMessageOrObject(gson.toJson(result)).build());
        responseObserver.onCompleted();
    }
}
