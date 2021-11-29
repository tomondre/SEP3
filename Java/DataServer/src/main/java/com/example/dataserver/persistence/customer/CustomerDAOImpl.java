package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class CustomerDAOImpl implements CustomerDAO
{

  private UserRepository repository;

  @Autowired
  public CustomerDAOImpl(UserRepository repository)
  {
    this.repository = repository;
  }

  @Override
  public User createCustomer(User customer)
  {
    return repository.save(customer);
  }
}
