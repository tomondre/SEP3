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

    @SerializedName(value = "isApproved", alternate = {"IsApproved"})
    @Column(name = "is_approved")
    private boolean isApproved = false;
  
    @SerializedName(value = "email", alternate = {"Email"})
    @Column(name = "email")
    private String email;

    @SerializedName(value = "password", alternate = {"Password"})
    @Column(name = "password")
    private String password;


    protected Provider() {
    }

    public String getCompanyName() {
        return companyName;
    }
  
    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Address address;

    @SerializedName(value = "email", alternate = {"Email"})
    @Column(name = "email")
    private String email;

    @SerializedName(value = "password", alternate = {"Password"})
    @Column(name = "password")
    private String password;

    protected Provider() {
        this.address = new Address();
    }

    public Provider(int id, String companyName, int cvr, String phoneNumber, String description, boolean isApproved, Address address, String email, String password) {
        this.id = id;
        this.companyName = companyName;
        this.cvr = cvr;
        this.phoneNumber = phoneNumber;
        this.description = description;
        this.isApproved = isApproved;
        this.address = address;
        this.email = email;
        this.password = password;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCompanyName() {
        return companyName;
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
                ", postCode=" + postCode + '\'' +
                ", city='" + city + '\'' +
                ", isApproved=" + isApproved + '\'' +
                ", email='" + email + '\'' +
                ", password='" + password +
                '}';
  
    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public int getCvr() {
        return cvr;
    }

    public void setCvr(int cvr) {
        this.cvr = cvr;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isApproved() {
        return isApproved;
    }

    public void setApproved(boolean approved) {
        isApproved = approved;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
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


    public void setApproved(boolean approved) {
        isApproved = approved;
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
}
