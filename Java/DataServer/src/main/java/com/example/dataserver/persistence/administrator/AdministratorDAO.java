package com.example.dataserver.persistence.administrator;

import com.example.dataserver.models.Administrator;

public interface AdministratorDAO
{
  Administrator getAdministratorById(int id);
  void createAdministrator(Administrator administrator);
  Administrator getAdministratorByEmail(String email);
}
