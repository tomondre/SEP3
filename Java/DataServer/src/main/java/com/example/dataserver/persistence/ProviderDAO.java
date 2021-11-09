package com.example.dataserver.persistence;

import com.example.dataserver.models.Provider;

import java.util.ArrayList;

public interface ProviderDAO {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
    Provider getProviderById(int id);
    void editProvider(Provider provider);
    void removeProvider(int id);
}