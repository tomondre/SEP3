package com.example.dataserver.networking;

import com.example.dataserver.models.Order;
import com.example.dataserver.persistence.order.OrderDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.order.OrderMessage;
import networking.order.OrderServiceGrpc;
import org.springframework.beans.factory.annotation.Autowired;

@GrpcService
public class OrderNetworking extends OrderServiceGrpc.OrderServiceImplBase {

    private OrderDAO orderDAO;

    @Autowired
    public OrderNetworking(OrderDAO orderDAO) {
        this.orderDAO = orderDAO;
    }

    @Override
    public void createOrder(OrderMessage request, StreamObserver<OrderMessage> responseObserver) {
        Order order = orderDAO.createOrder(new Order(request));
        responseObserver.onNext(order.toMessage());
        responseObserver.onCompleted();
    }
}
