package com.example.dataserver.models;


import com.google.gson.annotations.SerializedName;
import org.springframework.lang.Nullable;

import javax.persistence.*;

@Entity
@Table(name = "users")
public class User
{
  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  @Column(name = "user_id")
  private int id;

  @SerializedName(value = "email", alternate = {"Email"})
  @Column(name = "email")
  private String email;

  @SerializedName(value = "password", alternate = {"Password"})
  @Column(name = "password")
  private String password;

  @Column(name = "secirity_type")
  private String securityType;

  @Nullable
  @OneToOne(mappedBy = "user", cascade = CascadeType.ALL)
  private Provider provider;

  @Nullable
  @OneToOne(mappedBy = "user", cascade = CascadeType.ALL)
  private Customer customer;

  public User()
  {
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getEmail()
  {
    return email;
  }

  public void setEmail(String email)
  {
    this.email = email;
  }

  public String getPassword()
  {
    return password;
  }

  public void setPassword(String password)
  {
    this.password = password;
  }

  @Nullable
  public Provider getProvider()
  {
    return provider;
  }

  public void setProvider(@Nullable Provider provider)
  {
    this.provider = provider;
  }

  @Nullable
  public Customer getCustomer()
  {
    return customer;
  }

  public void setCustomer(@Nullable Customer customer)
  {
    this.customer = customer;
  }

  public String getSecurityType()
  {
    return securityType;
  }

  public void setSecurityType(String securityType)
  {
    this.securityType = securityType;
  }
}
