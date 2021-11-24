package com.example.dataserver.persistence.order;

import com.example.dataserver.models.Order;
import com.example.dataserver.persistence.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class OrderDAOImpl implements OrderDAO {

    private OrderRepository repository;

    @Autowired
    public OrderDAOImpl(OrderRepository repository) {
        this.repository = repository;
    }

    @Override
    public Order createOrder(Order order) {
        return repository.save(order);
    }
}
