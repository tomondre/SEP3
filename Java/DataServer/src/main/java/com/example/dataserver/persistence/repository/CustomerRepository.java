package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Customer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface CustomerRepository extends JpaRepository<Customer, Integer> {
  Customer getByEmail(@Param("email") String email);
}
