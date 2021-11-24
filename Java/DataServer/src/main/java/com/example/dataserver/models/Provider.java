package com.example.dataserver.models;

import com.google.gson.annotations.SerializedName;
import org.springframework.lang.Nullable;

import javax.persistence.*;

@Entity
@Table(name = "provider", schema = "sep3")
public class Provider {
    @Id
    @Column(name = "user_id")
    private int id;

    @SerializedName(value = "companyName", alternate = {"CompanyName"})
    @Nullable
    @Column(name = "company_name")
    private String companyName;

    @SerializedName(value = "cvr", alternate = {"Cvr"})
    @Nullable
    @Column(name = "cvr")
    private int cvr;

    @SerializedName(value = "phoneNumber", alternate = {"PhoneNumber"})
    @Nullable
    @Column(name = "phone_number")
    private String phoneNumber;

    @SerializedName(value = "description", alternate = {"Description"})
    @Nullable
    @Column(name = "description")
    private String description;

    @SerializedName(value = "isApproved", alternate = {"IsApproved"})
    @Nullable
    @Column(name = "is_approved")
    private boolean isApproved = false;

    @SerializedName(value = "address", alternate = {"Address"})
    @Nullable
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private Address address;

    @OneToOne
    @MapsId
    @JoinColumn(name="user_id")
    private User user;

    protected Provider() {
    }

    public String getCompanyName() {
        return companyName;
    }

    public Provider(int id, String companyName, int cvr, String phoneNumber, String description, boolean isApproved, Address address, String email, String password) {
        this.id = id;
        this.companyName = companyName;
        this.cvr = cvr;
        this.phoneNumber = phoneNumber;
        this.description = description;
        this.isApproved = isApproved;
        this.address = address;
    }

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setCompanyName(@Nullable String companyName)
    {
        this.companyName = companyName;
    }

    public int getCvr()
    {
        return cvr;
    }

    public void setCvr(int cvr)
    {
        this.cvr = cvr;
    }

    @Nullable
    public String getPhoneNumber()
    {
        return phoneNumber;
    }

    public void setPhoneNumber(@Nullable String phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    @Nullable
    public String getDescription()
    {
        return description;
    }

    public void setDescription(@Nullable String description)
    {
        this.description = description;
    }

    public boolean isApproved()
    {
        return isApproved;
    }

    public void setApproved(boolean approved)
    {
        isApproved = approved;
    }

    @Nullable
    public Address getAddress()
    {
        return address;
    }

    public void setAddress(@Nullable Address address)
    {
        this.address = address;
    }

    public User getUser()
    {
        return user;
    }

    public void setUser(User user)
    {
        this.user = user;
    }
}
