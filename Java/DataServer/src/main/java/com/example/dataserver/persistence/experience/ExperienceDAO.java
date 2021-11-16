package com.example.dataserver.persistence.experience;

import com.example.dataserver.models.Experience;
import com.example.dataserver.models.Provider;

import java.util.ArrayList;

public interface ExperienceDAO {
    Experience addExperience(Experience experience);
    ArrayList<Experience> getAllProviderExperiences(int provider);
    ArrayList<Experience> getAllWebShopExperiences();

}
