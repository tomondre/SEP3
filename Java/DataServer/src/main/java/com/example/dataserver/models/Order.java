package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;

import javax.persistence.*;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Set;

@Entity
@Table(name = "order", schema = "sep3")
public class Order {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "customer", alternate = {"Customer"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Customer customer;

    @SerializedName(value = "total", alternate = {"Total"})
    @Column(name = "total")
    private double total;

    @SerializedName(value = "comment", alternate = {"Comment"})
    @Column(name = "comment")
    private String comment;

    @SerializedName(value = "cratedOn", alternate = {"CreatedOn"})
    @Column(name = "date")
    private LocalDate date;

    @SerializedName(value = "items", alternate = {"Items"})
    @OneToMany(mappedBy = "order", fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Set<OrderItem> items;
}
