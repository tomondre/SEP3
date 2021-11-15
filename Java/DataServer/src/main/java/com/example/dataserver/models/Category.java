package com.example.dataserver.models;

import javax.persistence.*;

@Entity
@Table(name = "category", schema = "sep3")
public class Category
{
  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id")
  private int id;
  @Column(name = "category_name")
  private String categoryName;

  public Category()
  {
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getCategoryName()
  {
    return categoryName;
  }

  public void setCategoryName(String categoryName)
  {
    this.categoryName = categoryName;
  }

  @Override
  public String toString()
  {
    return "Category{" + "id=" + id + ", CategoryName='" + categoryName + '\'' + '}';
  }
}
