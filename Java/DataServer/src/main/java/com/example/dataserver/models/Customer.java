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
    private String firstName;

    @SerializedName(value = "lastName", alternate = {"LastName"})
    @Column(name = "last_name")
    private String lastName;

    @SerializedName(value = "phoneNumber", alternate = {"PhoneNumber"})
    @Column(name = "phone_number")
    private String phoneNumber;

    @SerializedName(value = "email", alternate = {"Email"})
    @Column(name = "email")
    private String email;

    @SerializedName(value = "password", alternate = {"Password"})
    @Column(name = "password")
    private String password;

    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Address address;

    public Customer() {

    }

    public Customer(int id, String firstName, String lastName, String phoneNumber, String email, String password, Address address) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.password = password;
        this.address = address;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
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
                ", email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", address=" + address +
                '}';
    }
}
