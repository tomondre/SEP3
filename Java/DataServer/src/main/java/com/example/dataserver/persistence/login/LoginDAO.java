package com.example.dataserver.persistence.login;

import com.example.dataserver.models.User;

import java.util.concurrent.Future;

public interface LoginDAO
{
  Future<User> getUserLogin(User userCred);
}
