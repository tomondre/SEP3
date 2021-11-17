package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Provider;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface ProviderRepository extends JpaRepository<Provider, Integer> {
    ArrayList<Provider> getAllByIsApproved(@Param("is_approved") boolean isApproved);
    Provider getByEmail(@Param("email")String email);
}
