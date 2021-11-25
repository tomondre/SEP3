package com.example.dataserver.persistence.login;

import com.example.dataserver.models.User;

public interface LoginDAO
{
  User getUserLogin(User userCred);
}
