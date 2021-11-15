package com.example.dataserver.models;
import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "customer", schema = "sep3")
public class Customer {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "firstName", alternate = {"FirstName"})
    @Column(name = "first_name")
    private int firstName;

    @SerializedName(value = "lastName", alternate = {"LastName"})
    @Column(name = "last_name")
    private int lastName;

    @SerializedName(value = "phoneNumber", alternate = {"PhoneNumber"})
    @Column(name = "phone_number")
    private String phoneNumber;

    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne
    private Address address;

    public Customer() {

    }

    public Customer(int id, int firstName, int lastName, String phoneNumber, Address address) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.address = address;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getFirstName() {
        return firstName;
    }

    public void setFirstName(int firstName) {
        this.firstName = firstName;
    }

    public int getLastName() {
        return lastName;
    }

    public void setLastName(int lastName) {
        this.lastName = lastName;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    @Override
    public String toString() {
        return "Customer{" +
                "id=" + id +
                ", firstName=" + firstName +
                ", lastName=" + lastName +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", address=" + address +
                '}';
    }
}
