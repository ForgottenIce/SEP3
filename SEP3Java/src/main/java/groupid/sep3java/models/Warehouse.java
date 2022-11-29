package groupid.sep3java.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.util.Objects;

@Entity
public class Warehouse {
	@Id @GeneratedValue(strategy = GenerationType.TABLE)
	private long id;
	private String address;

	public Warehouse() {
	}

	public Warehouse(String address) {
		this.address = address;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	@Override public boolean equals(Object o) {
		if (this == o)
			return true;
		if (!(o instanceof Warehouse))
			return false;
		Warehouse warehouse = (Warehouse) o;
		return id == warehouse.id && Objects.equals(address, warehouse.address);
	}

	@Override public int hashCode() {
		return Objects.hash(id, address);
	}

	@Override public String toString() {
		return "Warehouse{" + "Id=" + id + ", Address='" + address + '\'' + '}';
	}
}
