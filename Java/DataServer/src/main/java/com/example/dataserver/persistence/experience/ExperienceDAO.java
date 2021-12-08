package com.example.dataserver.persistence.experience;

import com.example.dataserver.models.Experience;

import java.util.ArrayList;
import java.util.List;

public interface ExperienceDAO {
    Experience addExperience(Experience experience);
    ArrayList<Experience> getAllProviderExperiences(int provider);
    ArrayList<Experience> getAllWebShopExperiences();
    Experience getExperienceById(int id);
    boolean isInStock(int id, int quantity);
    void deleteExperience(int experienceId);
    void removeStock(int id, int quantity);
    ArrayList<Experience> getAllProviderExperiencesByName(int id, String name);
    List<Experience> getExperienceByCategory(int id);
    ArrayList<Experience> getTopExperiences();
    ArrayList<Experience> getSortedExperiences(String name, double price);
    Experience editExperience(Experience experience);
}
