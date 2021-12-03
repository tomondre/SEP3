package com.example.dataserver.persistence.category;

import com.example.dataserver.models.Category;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

public interface CategoryDAO
{
  Category addProductCategory(Category category);
  Page<Category> getAllCategories(Pageable pageable);
  Category editProductCategory(Category category);
  void deleteProductCategory(int id);
}
