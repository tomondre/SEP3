package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;

import java.util.ArrayList;

public interface CustomerDAO
{
  User createCustomer(User customer);
  ArrayList<User> getAllCustomers();
  void deleteCustomer(int customerId);
  User getCustomerById(int id);
  User editCustomer(User customer);
  ArrayList<User> findCustomerByName(String name);
}
