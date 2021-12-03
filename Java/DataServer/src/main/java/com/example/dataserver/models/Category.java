package com.example.dataserver.models;

import com.google.gson.annotations.SerializedName;
import networking.category.CategoryMessage;

import javax.persistence.*;

@Entity
@Table(name = "category", schema = "sep3",
       uniqueConstraints = {@UniqueConstraint(columnNames = {"id", "category_name"})})
public class Category
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private int id;
    @Column(name = "category_name")
    @SerializedName(value = "categoryName", alternate = "CategoryName")
    private String categoryName;

    public Category()
    {
    }

    public Category(CategoryMessage categoryMessage)
    {
      this.id = categoryMessage.getId();
      this.categoryName = categoryMessage.getName();
    }

    public CategoryMessage toMessage()
    {
        return CategoryMessage.newBuilder().setId(id).setName(categoryName).build();
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
