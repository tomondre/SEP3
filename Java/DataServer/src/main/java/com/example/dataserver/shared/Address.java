package com.example.dataserver.shared;

public class Address {
    private String street;
    private String streetNumber;
    private int PostCode;
    private String City;


    public Address(String street, String streetNumber, int postCode, String city) {
        this.street = street;
        this.streetNumber = streetNumber;
        PostCode = postCode;
        City = city;
    }

    public String getStreet() {
        return street;
    }

    public String getStreetNumber() {
        return streetNumber;
    }

    public int getPostCode() {
        return PostCode;
    }

    public String getCity() {
        return City;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public void setStreetNumber(String streetNumber) {
        this.streetNumber = streetNumber;
    }

    public void setPostCode(int postCode) {
        PostCode = postCode;
    }

    public void setCity(String city) {
        City = city;
    }
}
