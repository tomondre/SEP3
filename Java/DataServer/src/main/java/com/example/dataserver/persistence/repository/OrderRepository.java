package com.example.dataserver.persistence.repository;

import com.example.dataserver.models.Order;
import com.example.dataserver.models.ProviderVouchers;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import javax.persistence.ColumnResult;
import javax.persistence.ConstructorResult;
import javax.persistence.SqlResultSetMapping;
import java.util.List;

@Repository
public interface OrderRepository extends JpaRepository<Order, Integer>
{
    Page<Order> getAllByUser_Id(@Param("customer_id") int id, Pageable pageable);

    Order getOrderById(@Param("id") int id);

//    @Query(value = "SELECT CONCAT_WS(' ', cust.first_name, cust.last_name) AS customerName, o.created_on AS date_created, oi.voucher AS voucher, oi.quantity AS quantity, oi.name AS experienceName FROM sep3.users us INNER JOIN sep3.customer AS cust ON us.user_id = cust.user_user_id INNER JOIN sep3.order AS o ON o.user_user_id = cust.user_user_id INNER JOIN sep3.order_item AS oi ON oi.order_id = o.id WHERE provider_user_id = ?1",
//           nativeQuery = true)
//    Page<ProviderVouchers> getProvidersVouchers(int providerId, Pageable pageable);"SELECT CONCAT_WS(' ', cust.first_name, cust.last_name) AS name, oi.voucher AS voucher, oi.quantity AS quantity, oi.name AS experienceName FROM sep3.users us INNER JOIN sep3.customer AS cust ON us.user_id = cust.user_user_id INNER JOIN sep3.order AS o ON o.user_user_id = cust.user_user_id INNER JOIN sep3.order_item AS oi ON oi.order_id = o.id WHERE provider_user_id = ?1


//    Page<ProviderVouchers> getProvidersVouchers(int providerId, Pageable pageable);

    @Query(nativeQuery = true,
           countQuery = "SELECT count(id) FROM sep3.users us INNER JOIN sep3.customer AS cust ON us.user_id = cust.user_user_id INNER JOIN sep3.order AS o ON o.user_user_id = cust.user_user_id INNER JOIN sep3.order_item AS oi ON oi.order_id = o.id WHERE provider_user_id = ?1")
    Page<ProviderVouchers> getProviderVouchers(int providerId, Pageable pageable);
}
