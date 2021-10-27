package com.example.dataserver.shared;

public class Provider {
    private String companyName;
    private int CVR;
    private String phoneNumber;
    private String description;
    private Address address;

    public Provider()
    {

    }

    public Provider(String companyName, int CVR, String phoneNumber, String description, Address address) {
        this.companyName = companyName;
        this.CVR = CVR;
        this.phoneNumber = phoneNumber;
        this.description = description;
        this.address = address;
    }

    public String getCompanyName() {
        return companyName;
    }

    public int getCVR() {
        return CVR;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public String getDescription() {
        return description;
    }

    public Address getAddress() {
        return address;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public void setCVR(int CVR) {
        this.CVR = CVR;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    @Override
    public String toString() {
        return "Provider{" +
                "companyName='" + companyName + '\'' +
                ", CVR=" + CVR +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", description='" + description + '\'' +
                ", address=" + address +
                '}';
    }
}
