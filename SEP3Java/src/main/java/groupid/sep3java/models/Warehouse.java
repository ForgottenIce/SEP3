package groupid.sep3java.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.util.Objects;

@Entity
public class Warehouse {
	@Id @GeneratedValue(strategy = GenerationType.TABLE)
	public long Id;
	public String Address;

	public Warehouse() {
	}

	public Warehouse(String address) {
		Address = address;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getAddress() {
		return Address;
	}

	public void setAddress(String address) {
		Address = address;
	}

	@Override public boolean equals(Object o) {
		if (this == o)
			return true;
		if (!(o instanceof Warehouse))
			return false;
		Warehouse warehouse = (Warehouse) o;
		return Id == warehouse.Id && Objects.equals(Address, warehouse.Address);
	}

	@Override public int hashCode() {
		return Objects.hash(Id, Address);
	}

	@Override public String toString() {
		return "Warehouse{" + "Id=" + Id + ", Address='" + Address + '\'' + '}';
	}
}
