package com.example.dataserver.persistence.category;

import com.example.dataserver.models.Category;

import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

public interface CategoryDAO
{
  Category addProductCategory(Category category);
  ArrayList<Category> getAllCategories();
  Category editProductCategory(Category category);
  void deleteProductCategory(int id);
}
