package com.example.dataserver.persistence.administrator;

import com.example.dataserver.models.Administrator;
import com.example.dataserver.persistence.repository.AdministratorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class AdministratorDAOImpl implements AdministratorDAO
{
  private final AdministratorRepository repository;

  @Autowired
  public AdministratorDAOImpl(AdministratorRepository repository)
  {
    this.repository = repository;
  }

  @Override
  public Administrator getAdministratorById(int id)
  {
    return repository.getById(id);
  }

  @Override
  public void createAdministrator(Administrator administrator)
  {
      repository.save(administrator);
  }

  @Override
  public Administrator getAdministratorByEmail(String email)
  {
    return repository.getByEmail(email);
  }
}
