package groupid.sep3java.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.util.Objects;
@Entity
public class Product {
	@Id @GeneratedValue(strategy = GenerationType.TABLE)
	private long Id;

	private String name;
	private String Description;
	private double Price;

	public Product() {
	}

	public Product( String description, double price) {
		Description = description;
		Price = price;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getDescription() {
		return Description;
	}

	public void setDescription(String description) {
		Description = description;
	}

	public double getPrice() {
		return Price;
	}

	public void setPrice(double price) {
		Price = price;
	}

	@Override public boolean equals(Object o) {
		if (this == o)
			return true;
		if (!(o instanceof Product))
			return false;
		Product product = (Product) o;
		return Id == product.Id && Double.compare(product.Price, Price) == 0
				&& Objects.equals(name, product.name) && Objects.equals(Description,
				product.Description);
	}

	@Override public int hashCode() {
		return Objects.hash(Id, name, Description, Price);
	}

	@Override public String toString() {
		return "Product{" + "Id=" + Id + ", name='" + name + '\''
				+ ", Description='" + Description + '\'' + ", Price=" + Price + '}';
	}
}
