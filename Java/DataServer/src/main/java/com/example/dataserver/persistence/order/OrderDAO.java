package com.example.dataserver.persistence.order;


import com.example.dataserver.models.Order;

public interface OrderDAO {
    Order createOrder(Order order);
}
