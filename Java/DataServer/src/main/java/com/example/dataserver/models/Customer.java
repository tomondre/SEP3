package com.example.dataserver.models;
import com.google.gson.annotations.SerializedName;
import org.springframework.lang.Nullable;

import javax.persistence.*;

@Entity
@Table(name = "customer", schema = "sep3")
public class Customer {

    @Id
    @Column(name = "user_id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "firstName", alternate = {"FirstName"})
    @Nullable
    @Column(name = "first_name")
    private String firstName;

    @SerializedName(value = "lastName", alternate = {"LastName"})
    @Nullable
    @Column(name = "last_name")
    private String lastName;

    @SerializedName(value = "phoneNumber", alternate = {"PhoneNumber"})
    @Nullable
    @Column(name = "phone_number")
    private String phoneNumber;

    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne(cascade = CascadeType.ALL)
    private Address address;

    @OneToOne
    @MapsId
    @JoinColumn(name="user_id")
    private User user;

    public Customer() {

    }

    public Customer(int id, String firstName, String lastName, String phoneNumber, Address address) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.address = address;
    }

}
