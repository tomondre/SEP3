package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;
import networking.order.OrderItemMessage;

import javax.persistence.*;

@Entity
@Table(name = "order_item", schema = "sep3")
public class OrderItem {

    @Id
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @PrimaryKeyJoinColumn(name = "id", referencedColumnName = "id")
    @MapsId
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

    public OrderItem(){

    }

    public OrderItem(OrderItemMessage item){
        id = item.getId();
        picture = item.getPicture();
        name = item.getName();
        price = item.getPrice();
        description = item.getDescription();
        quantity = item.getQuantity();
    }

    public OrderItemMessage toMessage(){
        return OrderItemMessage.newBuilder()
                .setId(id)
                .setPicture(picture)
                .setName(name)
                .setPrice(price)
                .setDescription(description)
                .setQuantity(quantity)
                .build();
    }
}
