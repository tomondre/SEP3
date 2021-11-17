package com.example.dataserver.persistence.provider;

import com.example.dataserver.models.Provider;
import com.example.dataserver.persistence.repository.ProviderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class ProviderDAOImpl implements ProviderDAO {

    private final ProviderRepository repo;

    @Autowired
    public ProviderDAOImpl(ProviderRepository repo) {
        this.repo = repo;
    }

    @Override
    public void createProvider(Provider provider) {
        repo.save(provider);
    }

    @Override
    public ArrayList<Provider> getAllProviders() {
        return repo.getAllByIsApproved(true);
    }

    @Override
    public Provider getProviderById(int id) {
        return repo.findById(id).orElseThrow();
    }

    @Override
    public void editProvider(Provider provider) {
        if (repo.existsById(provider.getId()))
            repo.save(provider);
    }

    @Override
    public void removeProvider(int id) {
        repo.deleteById(id);
    }

    @Override
    public ArrayList<Provider> getAllNotApprovedProviders() {
        return repo.getAllByIsApproved(false);
    }

    @Override
    public Provider getProviderByEmail(String email)
    {
        return repo.getByEmail(email);
    }
}
