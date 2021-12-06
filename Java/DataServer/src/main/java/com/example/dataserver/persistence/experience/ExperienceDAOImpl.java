package com.example.dataserver.persistence.experience;

import com.example.dataserver.models.Category;
import com.example.dataserver.models.Customer;
import com.example.dataserver.models.Experience;
import com.example.dataserver.models.User;
import com.example.dataserver.persistence.repository.ExperienceRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import java.util.ArrayList;
import java.util.List;

@Repository
//@EnableAsync
public class ExperienceDAOImpl implements ExperienceDAO
{
    @PersistenceContext
    private EntityManager em;
    private final ExperienceRepository repository;

    @Autowired
    public ExperienceDAOImpl(ExperienceRepository repository) {
        this.repository = repository;
    }

    // @Async
    @Override
    public Experience addExperience(Experience experience) {
        User user = em.getReference(User.class, experience.getExperienceProvider().getId());
        Category category = em.getReference(Category.class, experience.getExperienceCategory().getId());
        experience.setExperienceCategory(category);
        experience.setExperienceProvider(user);
        return repository.save(experience);
    }

    // @Async
    @Override
    public ArrayList<Experience> getAllProviderExperiences(int provider) {
        return repository.getAllByExperienceProviderId(provider);
    }

    // @Async
    @Override
    public ArrayList<Experience> getAllWebShopExperiences() {
        return repository.getAllByStockGreaterThan(0);
    }

    // @Async
    @Override
    public Experience getExperienceById(int id) {
        return repository.findById(id);
    }

    // @Async
    @Override
    public boolean isInStock(int id, int quantity) {
      return repository.existsByIdAndStockIsGreaterThanEqual(id, quantity);
    }

    // @Async
    @Override
    public void deleteExperience(int experienceId)
    {
        repository.deleteById(experienceId);
    }

    // @Async
    @Override
    public void removeStock(int id, int quantity) {
        Experience byId = repository.findById(id);
        byId.setStock(byId.getStock() - quantity);
        repository.save(byId);
    }

    // @Async
    @Override
    public List<Experience> getExperienceByCategory(int id) {
        Pageable page = PageRequest.of(1, 1);
        var allByExperienceCategoryIdAndStockGreaterThan =
                repository.getAllByExperienceCategoryIdAndStockGreaterThan(id, 0);
        return allByExperienceCategoryIdAndStockGreaterThan;
    }

    // @Async
    @Override
    public ArrayList<Experience> getAllProviderExperiencesByName(int id, String name)
    {
        return repository.findAllByExperienceProviderIdAndNameContainsIgnoreCase(id, name);
    }

    @Override
    public ArrayList<Experience> getTopExperiences() {
        return repository.findTop3ByStockAfter(0);
    }

    @Override
    public ArrayList<Experience> getExperiencesByName(String name) {
        return repository.getAllByNameContainsIgnoreCase(name);
    }
}
