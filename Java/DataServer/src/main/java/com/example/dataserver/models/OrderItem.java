package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "order_item", schema = "sep3")
public class OrderItem {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "order_id", nullable = false)
    private Order order;

    @SerializedName(value = "picture", alternate = {"Picture"})
    @Column(name = "picture")
    private String picture;

    @SerializedName(value = "name", alternate = {"Name"})
    @Column(name = "name")
    private String name;

    @SerializedName(value = "price", alternate = {"Price"})
    @Column(name = "price")
    private double price;

    @SerializedName(value = "description", alternate = {"Description"})
    @Column(name = "description")
    private String description;

    @SerializedName(value = "quantity", alternate = {"Quantity"})
    @Column(name = "quantity")
    private int quantity;
}
