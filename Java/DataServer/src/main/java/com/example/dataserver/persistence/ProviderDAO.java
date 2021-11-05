package com.example.dataserver.persistence;

import com.example.dataserver.shared.Provider;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

public interface ProviderDAO {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
    Provider getProviderById(int id);
    void editProvider(Provider provider);
    void removeProvider(int id);
}
