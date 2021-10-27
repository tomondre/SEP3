package com.example.dataserver.networking;

import com.example.dataserver.shared.Provider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;

public interface ProviderNetworking {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
}
