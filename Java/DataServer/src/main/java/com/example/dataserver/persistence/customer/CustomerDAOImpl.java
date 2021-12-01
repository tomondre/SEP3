package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

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

  @Override
  public ArrayList<User> getAllCustomers()
  {
    return repository.getAllByCustomer_FirstNameIsNotNull();
  }

  @Override
  public void deleteCustomer(int customerId)
  {
    repository.deleteById(customerId);
  }
}
