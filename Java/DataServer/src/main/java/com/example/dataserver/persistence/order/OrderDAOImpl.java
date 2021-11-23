package com.example.dataserver.persistence.order;

import com.example.dataserver.persistence.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class OrderDAOImpl implements OrderDAO {

    private OrderRepository repository;

    @Autowired
    public OrderDAOImpl() {
    }

    @Override
    public Order createOrder(Order order) {
        repository.save(order);
    }
}
