package com.example.dataserver.model;

import com.example.dataserver.persistence.ProviderPersistence;
import com.example.dataserver.shared.Provider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

@Component
public class ProviderModelImpl implements ProviderModel {

    private ProviderPersistence persistence;

    @Autowired
    public ProviderModelImpl(ProviderPersistence persistence)
    {
        this.persistence = persistence;
    }

    @Override
    public void createProvider(Provider provider) {
        persistence.createProvider(provider);
    }

    @Override
    public ArrayList<Provider> getAllProviders() {
        return persistence.getAllProviders();
    }
}
