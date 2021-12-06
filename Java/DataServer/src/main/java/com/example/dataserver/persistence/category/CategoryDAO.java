package com.example.dataserver.persistence.category;

import com.example.dataserver.models.Category;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.Future;

public interface CategoryDAO
{
  Future<Category> addProductCategory(Category category);
  Future<Page<Category>> getAllCategories(Pageable pageable);
  Future<Category> editProductCategory(Category category);
  void deleteProductCategory(int id);
}
