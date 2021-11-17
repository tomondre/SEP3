package com.example.dataserver.models;

//import com.example.dataserver.networking.ProtobufAddress;

import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "address", schema = "sep3", uniqueConstraints={@UniqueConstraint(columnNames ={"id", "city", "street", "street_no", "post_code"})})
public class Address {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "street", alternate = {"Street"})
    @Column(name = "street")
    private String street;

    @SerializedName(value = "streetNumber", alternate = {"StreetNumber"})
    @Column(name = "street_no")
    private String streetNumber;

    @SerializedName(value = "postCode", alternate = {"PostCode"})
    @Column(name = "post_code")
    private int postCode;

    @SerializedName(value = "city", alternate = {"City"})
    @Column(name = "city")
    private String city;


    protected Address() {
    }

    public Address(int id, String street, String streetNumber, int postCode, String city) {
        this.id = id;
        this.street = street;
        this.streetNumber = streetNumber;
        this.postCode = postCode;
        this.city = city;
    }

    @Override
    public String toString() {
        return "Address{" +
                "id=" + id +
                ", street='" + street + '\'' +
                ", streetNumber='" + streetNumber + '\'' +
                ", postCode=" + postCode +
                ", city='" + city + '\'' +
                '}';
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public String getStreetNumber() {
        return streetNumber;
    }

    public void setStreetNumber(String streetNumber) {
        this.streetNumber = streetNumber;
    }

    public int getPostCode() {
        return postCode;
    }

    public void setPostCode(int postCode) {
        this.postCode = postCode;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }
}
