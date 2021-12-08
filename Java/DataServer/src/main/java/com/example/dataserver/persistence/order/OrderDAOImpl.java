package com.example.dataserver.persistence.order;

import com.example.dataserver.models.Order;
import com.example.dataserver.models.OrderItem;
import com.example.dataserver.models.ProviderVouchers;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.AsyncResult;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Future;

@Repository
@EnableAsync
public class OrderDAOImpl implements OrderDAO {

    @PersistenceContext
    private EntityManager em;
    private OrderRepository repository;

    @Autowired
    public OrderDAOImpl(OrderRepository repository) {
        this.repository = repository;
    }

    @Async
    @Override
    public Future<Order> createOrder(Order order) {
        for (OrderItem item : order.getItems()) {
            item.setOrder(order);
            User reference = em.getReference(User.class, item.getProvider().getId());
            item.setProvider(reference);
        }
        order.setCreated_on(LocalDateTime.now());
        return new AsyncResult<>(repository.save(order));
    }

    @Async
    @Override
    public Future<Page<Order>> getAllCustomerOrders(int id, Pageable pageable) {
        return new AsyncResult<>(repository.getAllByUser_Id(id, pageable));
    }

    @Async
    @Override
    public Future<Order> getOrderById(int id) {
        return new AsyncResult<>(repository.getOrderById(id));
    }

    @Async
    @Override
    public Future<Page<ProviderVouchers>> getProviderVouchers(int providerId, Pageable pageable)
    {
//        List<ProviderVouchers> vouchers = em.createNamedQuery("getVouchers", ProviderVouchers.class).setParameter(1, providerId).getResultList();
//
        return new AsyncResult<>(repository.getProviderVouchers(providerId, pageable));
    }
}
