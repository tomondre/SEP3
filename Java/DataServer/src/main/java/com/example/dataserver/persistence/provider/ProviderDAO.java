package com.example.dataserver.persistence.provider;

import com.example.dataserver.models.Provider;
import com.example.dataserver.models.User;

import java.util.ArrayList;

public interface ProviderDAO {
    void createProvider(User provider);
    ArrayList<User> getAllProviders();
    User getProviderById(int id);
    void editProvider(User provider);
    void removeProvider(int id);
    ArrayList<User> getAllNotApprovedProviders();
}
