package com.example.dataserver.models;

import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "provider", schema = "sep3")
public class Provider {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    @SerializedName(value = "id", alternate = {"Id"})
    private int id;

    @SerializedName(value = "companyName", alternate = {"CompanyName"})
    @Column(name = "company_name")
    private String companyName;

    @SerializedName(value = "cvr", alternate = {"Cvr"})
    @Column(name = "cvr")
    private int cvr;

    @SerializedName(value = "phoneNumber", alternate = {"PhoneNumber"})
    @Column(name = "phone_number")
    private String phoneNumber;

    @SerializedName(value = "description", alternate = {"Description"})
    @Column(name = "description")
    private String description;

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

    @SerializedName(value = "isApproved", alternate = {"IsApproved"})
    @Column(name = "is_approved")
    private boolean isApproved = false;

    protected Provider() {
    }

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

//    public ProtobufProvider toProtobuf() {
//        ProtobufProvider.Builder builder = ProtobufProvider.newBuilder();
//        builder.setCompanyName(companyName);
//        builder.setCvr(cvr);
//        builder.setPhoneNumber(phoneNumber);
//        builder.setDescription(description);
//        builder.setId(id);
//        builder.setAddress(ProtobufAddress.newBuilder().setStreetNumber(streetNumber).setCity(city).setPostCode(postCode).setStreet(street).build());
//        return builder.build();
//    }


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
                ", isApproved=" + isApproved +
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

    public void setIsApproved(boolean approved) {
        isApproved = approved;
    }

    public boolean isApproved() {
        return isApproved;
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
