package com.example.dataserver.persistence.user;

import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.UserRepository;
import com.google.gson.Gson;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class UserDAOImpl implements UserDAO
{
  private UserRepository repository;
  private Gson gson;

  @Autowired
  public UserDAOImpl(UserRepository repository)
  {
    this.repository = repository;
    gson = new Gson();
  }

  @Override
  public void addProvider(User user)
  {
    var toSave = new User(securityType);


    //repository.save(toSave);

    print();
  }

  public void print()
  {
    ArrayList<User> allByUserInfo_isApproved = repository.getAllByProvider_isApproved(true);
    allByUserInfo_isApproved.forEach(System.out::println);
  }
}
