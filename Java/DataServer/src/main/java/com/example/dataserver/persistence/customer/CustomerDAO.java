package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;

public interface CustomerDAO
{
  User createCustomer(User customer);
  Page<User> getAllCustomers(Pageable pageable);
  void deleteCustomer(int customerId);
  User getCustomerById(int id);
  User editCustomer(User customer);
  Page<User> findCustomerByName(String name, Pageable pageable);
}
