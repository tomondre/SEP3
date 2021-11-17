package com.example.dataserver.persistence.provider;

import com.example.dataserver.models.Provider;

import java.util.ArrayList;

public interface ProviderDAO {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
    Provider getProviderById(int id);
    void editProvider(Provider provider);
    void removeProvider(int id);
    ArrayList<Provider> getAllNotApprovedProviders();
    Provider getProviderByEmail(String email);
}
