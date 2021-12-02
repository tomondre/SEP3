package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Order;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface OrderRepository extends JpaRepository<Order, Integer> {
    ArrayList<Order> getAllByUser_Id(@Param("customer_id") int id);
    Order getOrderById(@Param("id") int id);
}
