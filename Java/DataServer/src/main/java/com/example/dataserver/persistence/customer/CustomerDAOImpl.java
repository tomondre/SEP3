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
    return repository.getAllByCustomerTrue();
  }

  @Override
  public void deleteCustomer(int customerId)
  {
    repository.deleteById(customerId);
  }

  @Override
  public User getCustomerById(int id) {return repository.getUserById(id);
  }

  @Override
  public User editCustomer(User customer) {
    User toEdit = repository.getUserById(customer.getId());
    toEdit.getCustomer().setFirstName(customer.getCustomer().getFirstName());
    toEdit.getCustomer().setLastName(customer.getCustomer().getLastName());
    toEdit.getCustomer().setPhoneNumber(customer.getCustomer().getPhoneNumber());
    toEdit.setEmail(customer.getEmail());
    toEdit.setPassword(customer.getPassword());
    toEdit.getCustomer().getAddress().setStreet(customer.getCustomer().getAddress().getStreet());
    toEdit.getCustomer().getAddress().setStreetNumber(customer.getCustomer().getAddress().getStreetNumber());
    toEdit.getCustomer().getAddress().setCity(customer.getCustomer().getAddress().getCity());
    toEdit.getCustomer().getAddress().setPostCode(customer.getCustomer().getAddress().getPostCode());

    repository.save(toEdit);
    return toEdit;

  }
}
