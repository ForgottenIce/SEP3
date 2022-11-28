package groupid.sep3java.repositories;

import groupid.sep3java.models.WarehouseProduct;
import org.springframework.data.jpa.repository.JpaRepository;

public interface WarehouseProductRepository extends JpaRepository<WarehouseProduct, Long> {
}
