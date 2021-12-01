package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Experience;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface ExperienceRepository extends JpaRepository<Experience, Integer>
{
  ArrayList<Experience> getAllByExperienceProviderId(@Param("experience_provider_id") int id);
  Experience findById(@Param("id") int id);
  boolean existsByIdAndStockIsGreaterThanEqual(@Param("id") int id, @Param("stock") int quantity);
}
