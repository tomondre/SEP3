package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;
import networking.order.OrderItemMessage;
import networking.order.OrderMessage;

import javax.persistence.*;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

@NamedNativeQuery(name = "Order.getProviderVouchers",
                  query = "SELECT CONCAT_WS(' ', cust.first_name, cust.last_name) AS name, o.created_on AS dateCreated, oi.voucher AS voucher, oi.quantity AS quantity, oi.name AS experienceName FROM sep3.users us INNER JOIN sep3.customer AS cust ON us.user_id = cust.user_user_id INNER JOIN sep3.order AS o ON o.user_user_id = cust.user_user_id INNER JOIN sep3.order_item AS oi ON oi.order_id = o.id WHERE provider_user_id = ?1",
                  resultSetMapping = "Mapping.ProviderVouchers")

@SqlResultSetMapping(name = "Mapping.ProviderVouchers",
                     classes = @ConstructorResult(targetClass = ProviderVouchers.class,
                                                  columns = {@ColumnResult(name = "name"),
                                                             @ColumnResult(name = "dateCreated", type = LocalDateTime.class),
                                                             @ColumnResult(name = "voucher"),
                                                             @ColumnResult(name = "quantity"),
                                                             @ColumnResult(name = "experienceName")}))

@Entity
@Table(name = "order", schema = "sep3")
public class Order {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "user", alternate = {"User"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.MERGE)
    private User user;

    @SerializedName(value = "total", alternate = {"Total"})
    @Column(name = "total")
    private double total;

    @SerializedName(value = "comment", alternate = {"Comment"})
    @Column(name = "comment")
    private String comment;

    @SerializedName(value = "cratedOn", alternate = {"CreatedOn"})
    @Column(name = "createdOn")
    private LocalDateTime created_on;

    @SerializedName(value = "items", alternate = {"Items"})
    @OneToMany(mappedBy = "order", fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Set<OrderItem> items;

    public Order(){
    }

    public Order(OrderMessage order){
        id = order.getId();
        comment = order.getComment();
        total = order.getTotal();
        var user = new User();
        user.setId(order.getCustomerId());
        this.user = user;
        var arrayList  = new ArrayList<OrderItem>();
        for (OrderItemMessage item : order.getItemsList()) {
            arrayList.add(new OrderItem(item));
        }
        items = new HashSet<>(arrayList);
    }

    public OrderMessage toMessage() {
        ArrayList<OrderItemMessage> i = new ArrayList<>();
        for (OrderItem item : items) {
            i.add(item.toMessage());
        }

        DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ofPattern("yyyy MMMM dd HH:mm", Locale.ENGLISH);

        return OrderMessage.newBuilder()
                .setId(id)
                .setComment(comment)
                .setDate(created_on.format(dateTimeFormatter))
                .setTotal(total)
                .addAllItems(i)
                .build();
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public LocalDateTime getCreated_on() {
        return created_on;
    }

    public void setCreated_on(LocalDateTime created_on) {
        this.created_on = created_on;
    }

    public Set<OrderItem> getItems() {
        return items;
    }

    public void setItems(Set<OrderItem> items) {
        this.items = items;
    }
}
