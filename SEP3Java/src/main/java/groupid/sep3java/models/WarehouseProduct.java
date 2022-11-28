package groupid.sep3java.models;

import javax.persistence.*;
import java.util.Objects;
@Entity
public class WarehouseProduct {
	@Id @GeneratedValue(strategy = GenerationType.TABLE)
	public long productId;
	@ManyToOne
	public Warehouse warehouseID;
	public int quantity;
	public int minimumQuantity;
	public String shelf;
	public int shelfSection;

	public WarehouseProduct() {
	}

	public WarehouseProduct(Warehouse warehouseID, int quantity,
			int minimumQuantity, String shelf, int shelfSection) {
		this.warehouseID = warehouseID;
		this.quantity = quantity;
		this.minimumQuantity = minimumQuantity;
		this.shelf = shelf;
		this.shelfSection = shelfSection;
	}

	public long getProductId() {
		return productId;
	}

	public void setProductId(long productId) {
		this.productId = productId;
	}

	public Warehouse getWarehouseID() {
		return warehouseID;
	}

	public void setWarehouseID(Warehouse warehouseID) {
		this.warehouseID = warehouseID;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public int getMinimumQuantity() {
		return minimumQuantity;
	}

	public void setMinimumQuantity(int minimumQuantity) {
		this.minimumQuantity = minimumQuantity;
	}

	public String getShelf() {
		return shelf;
	}

	public void setShelf(String shelf) {
		this.shelf = shelf;
	}

	public int getShelfSection() {
		return shelfSection;
	}

	public void setShelfSection(int shelfSection) {
		this.shelfSection = shelfSection;
	}

	@Override public boolean equals(Object o) {
		if (this == o)
			return true;
		if (!(o instanceof WarehouseProduct))
			return false;
		WarehouseProduct that = (WarehouseProduct) o;
		return productId == that.productId && quantity == that.quantity
				&& minimumQuantity == that.minimumQuantity
				&& shelfSection == that.shelfSection && Objects.equals(warehouseID,
				that.warehouseID) && Objects.equals(shelf, that.shelf);
	}

	@Override public int hashCode() {
		return Objects.hash(productId, warehouseID, quantity, minimumQuantity,
				shelf, shelfSection);
	}

	@Override public String toString() {
		return "WarehouseProduct{" + "productId=" + productId + ", warehouseID="
				+ warehouseID + ", quantity=" + quantity + ", minimumQuantity="
				+ minimumQuantity + ", shelf='" + shelf + '\'' + ", shelfSection="
				+ shelfSection + '}';
	}
}
