package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Provider;
import com.example.dataserver.models.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface UserRepository extends JpaRepository<User, Integer>
{
  ArrayList<User> getAllByProvider_isApproved(@Param("is_approved") boolean userInfo_approved);
  ArrayList<User> getAllByProviderTrue();
  User getUserByEmailAndPassword(@Param("email")String email, @Param("password")String password);
  ArrayList<User> getAllByCustomer_FirstNameIsNotNull();
  ArrayList<User> findAllByCustomer_FirstNameContainingIgnoreCase(@Param("first_name") String name);
  ArrayList<User> findAllByProvider_isApprovedAndProvider_CompanyNameContainingIgnoreCase(@Param("is_approved") boolean isApproved, @Param("company_name") String name);
}
