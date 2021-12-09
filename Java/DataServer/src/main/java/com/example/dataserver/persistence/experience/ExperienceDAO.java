package com.example.dataserver.persistence.experience;

import com.example.dataserver.models.Experience;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;
import java.util.concurrent.Future;

public interface ExperienceDAO {
    Future<Experience> addExperience(Experience experience);
    Future<Page<Experience>> getAllProviderExperiences(int provider , Pageable pageable);
    Future<Page<Experience>> getAllWebShopExperiences(Pageable pageable);
    Future<Experience> getExperienceById(int id);
    Future<Boolean> isInStock(int id, int quantity);
    void deleteExperience(int experienceId);
    void removeStock(int id, int quantity);
    Future<Page<Experience>> getAllProviderExperiencesByName(int id, String name, Pageable pageable);
    Future<Page<Experience>> getExperienceByCategory(int id, Pageable pageable);
    Future<ArrayList<Experience>> getTopExperiences();
    Future<Page<Experience>> getSortedExperiences(String name, double price, Pageable pageable);
    Future<Experience> editExperience(Experience experience);
}
