package com.example.dataserver.shared;

import com.example.dataserver.networking.ProtobufAddress;
import com.example.dataserver.networking.ProtobufProvider;

import javax.persistence.*;


@Entity
@Table(name = "provider", schema = "sep3")
public class Provider {
    @Id
    @Column(name = "id")
    private int id;

    @Column(name = "company_name")
    private String companyName;

    @Column(name = "cvr")
    private int cvr;

    @Column(name = "phone_number")
    private String phoneNumber;

    @Column(name = "description")
    private String description;

    @Column(name = "street")
    private String street;

    @Column(name = "street_no")
    private String streetNumber;

    @Column(name = "post_code")
    private int postCode;

    @Column(name = "city")
    private String city;

    protected Provider() {
    }

    public Provider(ProtobufProvider provider) {
        companyName = provider.getCompanyName();
        cvr = provider.getCvr();
        phoneNumber = provider.getPhoneNumber();
        description = provider.getDescription();
        street = provider.getAddress().getStreet();
        streetNumber = provider.getAddress().getStreetNumber();
        postCode = provider.getAddress().getPostCode();
        city = provider.getAddress().getCity();
    }

//    public Provider(int id, String companyName, int cvr, String phoneNumber, String description, String street, String streetNumber, int postCode, String city) {
//        this.id = id;
//        this.companyName = companyName;
//        this.cvr = cvr;
//        this.phoneNumber = phoneNumber;
//        this.description = description;
//        this.street = street;
//        this.streetNumber = streetNumber;
//        this.postCode = postCode;
//        this.city = city;
//    }

    public String getCompanyName() {
        return companyName;
    }

    public int getCVR() {
        return cvr;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public String getDescription() {
        return description;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public void setCVR(int CVR) {
        this.cvr = CVR;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public ProtobufProvider toProtobuf() {
        ProtobufProvider.Builder builder = ProtobufProvider.newBuilder();
        builder.setCompanyName(companyName);
        builder.setCvr(cvr);
        builder.setPhoneNumber(phoneNumber);
        builder.setDescription(description);
        builder.setAddress(ProtobufAddress.newBuilder().setStreetNumber(streetNumber).setCity(city).setPostCode(postCode).setStreet(street).build());
        return builder.build();
    }

    @Override
    public String toString() {
        return "Provider{" +
                "id=" + id +
                ", companyName='" + companyName + '\'' +
                ", cvr=" + cvr +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", description='" + description + '\'' +
                ", street='" + street + '\'' +
                ", streetNumber='" + streetNumber + '\'' +
                ", postCode=" + postCode +
                ", city='" + city + '\'' +
                '}';
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setCvr(int cvr) {
        this.cvr = cvr;
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

    public int getId() {
        return id;
    }

    public int getCvr() {
        return cvr;
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
}
