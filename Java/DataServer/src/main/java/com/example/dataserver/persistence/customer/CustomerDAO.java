package com.example.dataserver.persistence.customer;

import com.example.dataserver.models.Customer;
import com.example.dataserver.models.User;

public interface CustomerDAO {

    Customer createCustomer(User customer);
}
