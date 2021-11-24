package com.example.dataserver.persistence.user;

import com.example.dataserver.models.User;

public interface UserDAO
{
  void addProvider(User userInfo);
}
