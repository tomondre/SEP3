package com.example.dataserver.persistence;

import com.example.dataserver.shared.Provider;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

public interface ProviderPersistence {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
}
