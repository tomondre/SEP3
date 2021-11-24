package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.CustomerRepository;
import com.example.dataserver.persistence.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class CustomerDAOImpl implements CustomerDAO {

    private UserRepository repository;

    @Autowired
    public CustomerDAOImpl(UserRepository repository) {
        this.repository = repository;
    }

    @Override
    public Customer createCustomer(User customer) {
        repository.save(customer);
        return null;
    }
}
