package com.example.dataserver.persistence.provider;

import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class ProviderDAOImpl implements ProviderDAO {

    private final UserRepository repo;

    @Autowired
    public ProviderDAOImpl(UserRepository repo) {
        this.repo = repo;
    }

    @Override
    public void createProvider(User provider) {
        repo.save(provider);
    }

    @Override
    public ArrayList<User> getAllProviders() {
        return repo.getAllByProvider_isApproved(true);
    }

    @Override
    public User getProviderById(int id) {
        return repo.findById(id).orElseThrow();
    }

    @Override
    public void editProvider(User provider) {
        if (repo.existsById(provider.getId()))
            repo.save(provider);
    }

    @Override
    public void removeProvider(int id) {
        repo.deleteById(id);
    }

    @Override
    public ArrayList<User> getAllNotApprovedProviders() {
        return repo.getAllByProvider_isApproved(true);
    }


}
