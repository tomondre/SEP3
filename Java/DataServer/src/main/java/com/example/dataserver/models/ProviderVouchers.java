package com.example.dataserver.models;

public class ProviderVouchers
{
    private String customerName;
    private String date;
    private String voucher;
    private int quantity;
    private String experienceName;

    public ProviderVouchers()
    {
    }

    public String getCustomerName()
    {
        return customerName;
    }

    public void setCustomerName(String customerName)
    {
        this.customerName = customerName;
    }

    public String getDate()
    {
        return date;
    }

    public void setDate(String date)
    {
        this.date = date;
    }

    public String getVoucher()
    {
        return voucher;
    }

    public void setVoucher(String voucher)
    {
        this.voucher = voucher;
    }

    public int getQuantity()
    {
        return quantity;
    }

    public void setQuantity(int quantity)
    {
        this.quantity = quantity;
    }

    public String getExperienceName()
    {
        return experienceName;
    }

    public void setExperienceName(String experienceName)
    {
        this.experienceName = experienceName;
    }
}
