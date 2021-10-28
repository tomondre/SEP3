package com.example.dataserver.shared;

import com.example.dataserver.networking.ProtobufProvider;
import net.badata.protobuf.converter.annotation.ProtoClass;
import net.badata.protobuf.converter.annotation.ProtoField;

@ProtoClass(ProtobufProvider.class)
public class Provider {
    @ProtoField
    private String companyName;
    @ProtoField
    private int cvr;
    @ProtoField
    private String phoneNumber;
    @ProtoField
    private String description;
    private Address address;

    public Provider()
    {
        address = new Address();
    }

    public Provider(ProtobufProvider provider)
    {
        companyName = provider.getCompanyName();
        cvr = provider.getCvr();
        phoneNumber = provider.getPhoneNumber();
        description = provider.getDescription();
        address = new Address(provider.getAddress());
    }

    public Provider(String companyName, int CVR, String phoneNumber, String description, Address address) {
        this.companyName = companyName;
        this.cvr = CVR;
        this.phoneNumber = phoneNumber;
        this.description = description;
        this.address = address;
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

    public Address getAddress() {
        return address;
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

    public void setAddress(Address address) {
        this.address = address;
    }

    public ProtobufProvider toProtobuf()
    {
        ProtobufProvider.Builder builder = ProtobufProvider.newBuilder();
        builder.setCompanyName(companyName);
        builder.setCvr(cvr);
        builder.setPhoneNumber(phoneNumber);
        builder.setDescription(description);
        builder.setAddress(address.toProtobuf());
        return builder.build();
    }

    @Override
    public String toString() {
        return "Provider{" +
                "companyName='" + companyName + '\'' +
                ", CVR=" + cvr +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", description='" + description + '\'' +
                ", address=" + address +
                '}';
    }
}
