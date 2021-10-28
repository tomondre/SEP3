package com.example.dataserver.shared;

import com.example.dataserver.networking.ProtobufAddress;
import net.badata.protobuf.converter.annotation.ProtoClass;
import net.badata.protobuf.converter.annotation.ProtoField;

@ProtoClass(ProtobufAddress.class)
public class Address {
    @ProtoField
    private String street;
    @ProtoField
    private String streetNumber;
    @ProtoField
    private int postCode;
    @ProtoField
    private String city;

    public Address(ProtobufAddress address)
    {
        street = address.getStreet();
        streetNumber = address.getStreetNumber();
        postCode = address.getPostCode();
        city = address.getCity();
    }

    public Address()
    {
        street = "";
        streetNumber = "";
        postCode = 0;
        city = "";
    }

    public Address(String street, String streetNumber, int postCode, String city) {
        this.street = street;
        this.streetNumber = streetNumber;
        this.postCode = postCode;
        this.city = city;
    }

    public ProtobufAddress toProtobuf()
    {
        ProtobufAddress.Builder builder = ProtobufAddress.newBuilder();
        builder.setCity(city);
        builder.setPostCode(postCode);
        builder.setStreet(street);
        builder.setStreetNumber(streetNumber);
        return builder.build();
    }

    public String getStreet() {
        return street;
    }

    public String getStreetNumber() {
        return streetNumber;
    }

    public int getPostCode() {
        return postCode;
    }

    public String getCity() {
        return city;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public void setStreetNumber(String streetNumber) {
        this.streetNumber = streetNumber;
    }

    public void setPostCode(int postCode) {
        this.postCode = postCode;
    }

    public void setCity(String city) {
        this.city = city;
    }
}
