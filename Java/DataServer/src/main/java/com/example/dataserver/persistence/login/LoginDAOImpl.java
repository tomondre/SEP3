package com.example.dataserver.persistence.login;

import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.UserRepository;
import com.google.gson.Gson;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class LoginDAOImpl implements LoginDAO
{
  private UserRepository repository;
  private Gson gson;

  @Autowired
  public LoginDAOImpl(UserRepository repository)
  {
    this.repository = repository;
    gson = new Gson();
  }

  @Override
  public User getUserLogin(User userCred)
  {
    return repository.getUserByEmailAndPassword(userCred.getEmail(),
        userCred.getPassword());
  }
}
