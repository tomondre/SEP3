package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;
import networking.order.OrderItemMessage;
import networking.order.OrderMessage;

import javax.persistence.*;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Set;

@Entity
@Table(name = "order", schema = "sep3")
public class Order {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "user", alternate = {"User"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private User user;

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

    public Order(){
    }

    public Order(OrderMessage order){
        id = order.getId();
        comment = order.getComment();
        date = LocalDate.parse(order.getDate());
        total = order.getTotal();
        for (OrderItemMessage item : order.getItemsList()) {
            items.add(new OrderItem(item));
        }
    }

    public OrderMessage toMessage() {
        ArrayList<OrderItemMessage> i = new ArrayList<>();
        for (OrderItem item : items) {
            i.add(item.toMessage());
        }

        return OrderMessage.newBuilder()
                .setId(id)
                .setComment(comment)
                .setDate(date.toString())
                .setTotal(total)
                .addAllItems(i)
                .build();
    }
}
