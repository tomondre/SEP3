package com.example.dataserver.models;

import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "experience", schema = "sep3")
public class Experience
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "picture", alternate = {"Picture"})
    @Column(name = "picture")
    private String picture;

    @SerializedName(value = "name", alternate = {"Name"})
    @Column(name = "name")
    private String name;

    @SerializedName(value = "price", alternate = {"Price"})
    @Column(name = "price")
    private double price;

    @SerializedName(value = "stock", alternate = {"Stock"})
    @Column(name = "stock")
    private int stock;

    @SerializedName(value = "description", alternate = {"Description"})
    @Column(name = "description")
    private String description;

    @SerializedName(value = "experienceValidity", alternate = {"ExperienceValidity"})
    @Column(name = "experience_Validity")
    private String experienceValidity;

    @SerializedName(value = "experienceCategory", alternate = {"ExperienceCategory"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Category experienceCategory;

    @SerializedName(value = "experienceProvider", alternate = {"ExperienceProvider"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private User experienceProvider;

    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private  Address address;

    public Experience()
    {
    }

    public Experience(int id, String picture, String name, double price,int stock, String description, String experienceValidity, Category experienceCategory, Provider experienceProvider, Address address) {
        this.id = id;
        this.picture = picture;
        this.name = name;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.experienceValidity = experienceValidity;
        this.experienceCategory = experienceCategory;
        this.experienceProvider = experienceProvider;
        this.address = address;
    }

    @Override
    public String toString() {
        return "Experience{" +
                "id=" + id +
                ", picture='" + picture + '\'' +
                ", name='" + name + '\'' +
                ", price=" + price +
                ", stock=" + stock +
                ", description='" + description + '\'' +
                ", experienceValidity='" + experienceValidity + '\'' +
                ", experienceCategory=" + experienceCategory +
                ", experienceProvider=" + experienceProvider +
                ", address=" + address +
                '}';
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getExperienceValidity() {
        return experienceValidity;
    }

    public void setExperienceValidity(String experienceValidity) {
        this.experienceValidity = experienceValidity;
    }

    public Category getExperienceCategory() {
        return experienceCategory;
    }

    public void setExperienceCategory(Category experienceCategory) {
        this.experienceCategory = experienceCategory;
    }

    public User getExperienceProvider() {
        return experienceProvider;
    }

    public void setExperienceProvider(User experienceProvider) {
        this.experienceProvider = experienceProvider;
    }

    public int getStock()
    {
        return stock;
    }

    public void setStock(int stock)
    {
        this.stock = stock;
    }
}
