package com.example.dataserver.models;

import jdk.jfr.DataAmount;
import networking.order.OrderItemMessage;
import networking.order.VoucherMessages;

import javax.persistence.*;


@SqlResultSetMapping(name = "voucherResult", classes = {
        @ConstructorResult(targetClass = com.example.dataserver.models.ProviderVouchers.class,
        columns = {
                @ColumnResult(name = "name"),
                @ColumnResult(name = "dateCreated"),
                @ColumnResult(name = "voucher"),
                @ColumnResult(name = "quantity"),
                @ColumnResult(name = "experienceName")})})

@NamedNativeQuery(name = "getVouchers",
        query = "SELECT CONCAT_WS(' ', cust.first_name, cust.last_name) AS name, o.created_on AS dateCreated, oi.voucher AS voucher, oi.quantity AS quantity, oi.name AS experienceName FROM sep3.users us INNER JOIN sep3.customer AS cust ON us.user_id = cust.user_user_id INNER JOIN sep3.order AS o ON o.user_user_id = cust.user_user_id INNER JOIN sep3.order_item AS oi ON oi.order_id = o.id WHERE provider_user_id = ?1",
        resultSetMapping = "voucherResult")

public class ProviderVouchers {

    private String name;
    private String dateCreated;
    private String voucher;
    private int quantity;
    private String experienceName;

    public ProviderVouchers(String name, String dateCreated, String voucher, int quantity, String experienceName) {
        this.name = name;
        this.dateCreated = dateCreated;
        this.voucher = voucher;
        this.quantity = quantity;
        this.experienceName = experienceName;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDateCreated() {
        return dateCreated;
    }

    public void setDateCreated(String dateCreated) {
        this.dateCreated = dateCreated;
    }

    public String getVoucher() {
        return voucher;
    }

    public void setVoucher(String voucher) {
        this.voucher = voucher;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public String getExperienceName() {
        return experienceName;
    }

    public void setExperienceName(String experienceName) {
        this.experienceName = experienceName;
    }

    public ProviderVouchers(ProviderVouchers item) {
//        customerName = item.getCustomerName();
//        date = item.getCustomerName();
//        voucher = item.getVoucher();
//        quantity = item.getQuantity();
        experienceName = item.experienceName;
    }

    public VoucherMessages toMessage() {
        return VoucherMessages.newBuilder()
//                .setCustomerName(customerName)
//                .setDate(date)
//                .setVoucher(voucher)
//                .setQuantity(quantity)
//                .setExperienceName(experienceName)
                .build();
    }

}
