package com.example.dataserver.networking;

import com.example.dataserver.models.Order;
import com.example.dataserver.persistence.order.OrderDAO;
import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import networking.order.OrderListMessage;
import networking.order.OrderMessage;
import networking.order.OrderServiceGrpc;
import networking.user.UserMessage;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.ArrayList;

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

    @Override
    public void getAllCustomerOrders(UserMessage request, StreamObserver<OrderListMessage> responseObserver) {
        ArrayList<Order> orders = orderDAO.getAllCustomerOrders(request.getId());
        ArrayList<OrderMessage> orderMessages = new ArrayList<>();
        for (Order order : orders) {
            orderMessages.add(order.toMessage());
        }
        responseObserver.onNext(OrderListMessage.newBuilder().addAllOrders(orderMessages).build());
        responseObserver.onCompleted();
    }

    @Override
    public void getOrderById(OrderMessage request, StreamObserver<OrderMessage> responseObserver) {
        Order orderById = orderDAO.getOrderById(request.getId());
        responseObserver.onNext(orderById.toMessage());
        responseObserver.onCompleted();
    }
}
