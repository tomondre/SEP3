package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Administrator;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface AdministratorRepository extends JpaRepository<Administrator, Integer>
{
  Administrator getByEmail(@Param("email") String email);
}
