package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Order;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface OrderRepository extends JpaRepository<Order, Integer> {
    Page<Order> getAllByUser_Id(@Param("customer_id") int id, Pageable pageable);
    Order getOrderById(@Param("id") int id);
}
