package com.example.dataserver.persistence.provider;

import com.example.dataserver.models.Provider;
import com.example.dataserver.models.User;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;
import java.util.concurrent.Future;

public interface ProviderDAO {
    Future<User> createProvider(User provider);
    Future<Page<User>> getAllProviders(Pageable pageable);
    Future<User> getProviderById(int id);
    Future<User> editProvider(User provider);
    void removeProvider(int id);
    Future<Page<User>> getAllNotApprovedProviders(Pageable pageable);
    Future<Page<User>> getAllByName(String name, Pageable pageable);
}
