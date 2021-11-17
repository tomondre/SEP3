package com.example.dataserver.models;

import com.google.gson.annotations.SerializedName;

import javax.persistence.*;

@Entity
@Table(name = "administrator", schema = "sep3")
public class Administrator
{
  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id")
  @SerializedName(value = "id", alternate = {"Id"})
  private int id;

  @SerializedName(value = "firstName", alternate = {"FirstName"})
  @Column(name = "first_name")
  private String firstName;

  @SerializedName(value = "lastName", alternate = {"LastName"})
  @Column(name = "last_name")
  private String lastName;

  @SerializedName(value = "email", alternate = {"Email"})
  @Column(name = "email")
  private String email;

  @SerializedName(value = "password", alternate = {"Password"})
  @Column(name = "password")
  private String password;

  public Administrator()
  {
  }

  public Administrator(int id, String firstName, String lastName, String email, String password)
  {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.password = password;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getFirstName()
  {
    return firstName;
  }

  public void setFirstName(String firstName)
  {
    this.firstName = firstName;
  }

  public String getLastName()
  {
    return lastName;
  }

  public void setLastName(String lastName)
  {
    this.lastName = lastName;
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

  @Override
  public String toString()
  {
    return "Administrator{" + "id=" + id + ", firstName='" + firstName + '\'' + ", lastName='"
        + lastName + '\'' + ", email='" + email + '\'' + ", password='" + password + '\'' + '}';
  }
}
