package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Experience;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ExperienceRepository extends JpaRepository<Experience, Integer>
{
}
