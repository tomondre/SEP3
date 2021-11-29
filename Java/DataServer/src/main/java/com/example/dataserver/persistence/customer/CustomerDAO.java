package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.User;

public interface CustomerDAO
{
  User createCustomer(User customer);
}
