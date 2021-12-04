package com.example.dataserver.persistence.order;

import com.example.dataserver.models.Order;
import com.example.dataserver.models.OrderItem;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;

@Repository
public class OrderDAOImpl implements OrderDAO {

    @PersistenceContext
    private EntityManager em;
    private OrderRepository repository;

    @Autowired
    public OrderDAOImpl(OrderRepository repository) {
        this.repository = repository;
    }

    @Override
    public Order createOrder(Order order) {
        for (OrderItem item : order.getItems()) {
            item.setOrder(order);
            User reference = em.getReference(User.class, item.getProvider().getId());
            item.setProvider(reference);
        }
        order.setCreated_on(LocalDateTime.now());
        return repository.save(order);
    }

    @Override
    public ArrayList<Order> getAllCustomerOrders(int id) {
        return repository.getAllByUser_Id(id);
    }

    @Override
    public Order getOrderById(int id) {
        return repository.getOrderById(id);
    }
}
