package com.example.dataserver.model;

import com.example.dataserver.shared.Provider;

import java.util.ArrayList;

public interface ProviderModel {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
}
