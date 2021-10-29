package com.example.dataserver.model;

import com.example.dataserver.shared.Provider;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

public interface ProviderModel {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
    Provider getProviderById(int id);
    void editProvider(Provider provider);
}
