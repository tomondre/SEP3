package com.example.dataserver.networking;

import com.example.dataserver.shared.Provider;

import java.util.ArrayList;

public interface ProviderNetworking {
    void createProvider(Provider provider);
    ArrayList<Provider> getAllProviders();
}
