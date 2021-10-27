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

    private final JdbcTemplate template;

    @Autowired
    public ProviderPersistenceImpl(JdbcTemplate template) {
        this.template = template;
    }

    @Override
    public void createProvider(Provider provider) {
        String sql = "INSERT INTO provider (company_name, cvr, phone_number, description, street, street_no, post_code, city) VALUES (?, ?, ?, ?, ?, ?, ?,?)";
        template.update(sql, provider.getCompanyName(), provider.getCVR(), provider.getPhoneNumber(), provider.getDescription(), provider.getAddress().getStreet(), provider.getAddress().getStreetNumber(), provider.getAddress().getPostCode(), provider.getAddress().getCity());
    }

    @Override
    public ArrayList<Provider> getAllProviders() {
        String sql = "SELECT * FROM provider";
        return (ArrayList<Provider>) template.query(sql, new BeanPropertyRowMapper(Provider.class));
    }
}
