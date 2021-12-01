package com.example.dataserver.persistence.experience;

import com.example.dataserver.models.Experience;
import com.example.dataserver.persistence.repository.ExperienceRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class ExperienceDAOImpl implements ExperienceDAO
{
    private final ExperienceRepository repository;

    @Autowired
    public ExperienceDAOImpl(ExperienceRepository repository) {
        this.repository = repository;
    }

    @Override
    public Experience addExperience(Experience experience) {
        return repository.save(experience);
    }

    @Override
    public ArrayList<Experience> getAllProviderExperiences(int provider) {
        return repository.getAllByExperienceProviderId(provider);
    }

    @Override
    public ArrayList<Experience> getAllWebShopExperiences() {
        return (ArrayList<Experience>) repository.findAll();
    }

    @Override
    public Experience getExperienceById(int id) {
        return repository.findById(id);
    }

    @Override
    public boolean isInStock(int id, int quantity) {
      return repository.existsByIdAndStockIsGreaterThanEqual(id, quantity);
    }

    @Override
    public void deleteExperience(int experienceId)
    {
        repository.deleteById(experienceId);
    }

    @Override
    public void removeStock(int id, int quantity) {
        Experience byId = repository.findById(id);
        byId.setStock(byId.getStock() - quantity);
        repository.save(byId);
    }
}
