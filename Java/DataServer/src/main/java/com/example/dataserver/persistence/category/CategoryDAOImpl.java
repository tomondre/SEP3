package com.example.dataserver.persistence.category;

import com.example.dataserver.models.Category;
import com.example.dataserver.persistence.repository.ProductCategoryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class CategoryDAOImpl implements CategoryDAO
{
  private final ProductCategoryRepository repository;

  @Autowired
  public CategoryDAOImpl(ProductCategoryRepository repository)
  {
    this.repository = repository;
  }

  @Override
  public Category addProductCategory(Category category)
  {
    return repository.save(category);
  }

  @Override
  public ArrayList<Category> getAllCategories()
  {
    return (ArrayList<Category>) repository.findAll();
  }

  @Override
  public Category editProductCategory(Category category)
  {
    return repository.save(category);
  }

  @Override
  public void deleteProductCategory(int id)
  {
    repository.deleteById(id);
  }
}
