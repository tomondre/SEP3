package com.example.dataserver.persistence.order;


import com.example.dataserver.models.Order;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.concurrent.Future;

public interface OrderDAO {
    Future<Order> createOrder(Order order);
    Future<Page<Order>> getAllCustomerOrders(int id, Pageable pageable);
    Future<Order> getOrderById(int id);
}
