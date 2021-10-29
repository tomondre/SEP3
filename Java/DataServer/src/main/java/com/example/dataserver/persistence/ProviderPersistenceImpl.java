package com.example.dataserver.persistence;

import com.example.dataserver.shared.Address;
import com.example.dataserver.shared.Provider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

import java.sql.PreparedStatement;
import java.util.ArrayList;

@Repository
public class ProviderPersistenceImpl implements ProviderPersistence {

    private final ProviderRepository repo;

    @Autowired
    public ProviderPersistenceImpl(ProviderRepository repo) {
        this.repo = repo;
    }

    @Override
    public void createProvider(Provider provider) {
        repo.save(provider);
    }

    @Override
    public ArrayList<Provider> getAllProviders() {
        return (ArrayList<Provider>) repo.findAll();
    }

    @Override
    public Provider getProviderById(int id) {
        return repo.findById(id).orElseThrow();
    }
}
