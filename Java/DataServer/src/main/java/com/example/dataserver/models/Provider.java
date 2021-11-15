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

    @SerializedName(value = "address", alternate = {"Address"})
    @ManyToOne
    private Address address;

    protected Provider() {
        this.address = new Address();
    }

    @Override
    public String toString() {
        return "Provider{" +
                "id=" + id +
                ", companyName='" + companyName + '\'' +
                ", cvr=" + cvr +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", description='" + description + '\'' +
                ", isApproved=" + isApproved +
                ", address=" + address +
                '}';
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
}
