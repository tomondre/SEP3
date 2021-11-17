package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.persistence.repository.CustomerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class CustomerDAOImpl implements CustomerDAO {

    private CustomerRepository repository;

    @Autowired
    public CustomerDAOImpl(CustomerRepository repository) {
        this.repository = repository;
    }

    @Override
    public Customer createCustomer(Customer customer) {
        Customer save = repository.save(customer);
        return save;
    }

    @Override
    public Customer getCustomerByEmail(String email)
    {
        return repository.getByEmail(email);
    }
}
