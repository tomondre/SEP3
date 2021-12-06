package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;
import java.util.concurrent.Future;

public interface CustomerDAO
{
  Future<User> createCustomer(User customer);
  Future<Page<User>> getAllCustomers(Pageable pageable);
  void deleteCustomer(int customerId);
  Future<User> getCustomerById(int id);
  Future<User> editCustomer(User customer);
  Future<Page<User>> findCustomerByName(String name, Pageable pageable);
}
