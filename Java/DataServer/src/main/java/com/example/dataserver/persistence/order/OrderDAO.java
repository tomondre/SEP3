package com.example.dataserver.persistence.order;


import com.example.dataserver.models.Order;
import org.springframework.data.repository.query.Param;

import java.util.ArrayList;

public interface OrderDAO {
    Order createOrder(Order order);
    ArrayList<Order> getAllCustomerOrders(int id);
    Order getOrderById(int id);
}
