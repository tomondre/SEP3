package com.example.dataserver.networking;

import com.example.dataserver.model.ProviderModel;
import com.example.dataserver.shared.Provider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import java.util.ArrayList;

@Service
public class ProviderNetworkingImpl implements ProviderNetworking
{
    private ProviderModel model;

    @Autowired
    public ProviderNetworkingImpl(ProviderModel model)
    {
        this.model = model;
    }

    @Override
    public void createProvider(Provider provider) {
        model.createProvider(provider);
    }

    @Override
    public ArrayList<Provider> getAllProviders() {
        return model.getAllProviders();
    }
}
