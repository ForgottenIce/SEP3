package groupid.sep3java.models;

import javax.persistence.*;
import java.util.Date;
import java.util.Objects;

@Entity(name = "orderPlaced")
public class Order {
	@Id @GeneratedValue(strategy = GenerationType.TABLE)
	private long id;
	@ManyToOne
	private Customer customer;
	@Temporal(TemporalType.DATE)
	private Date dateTimeOrdered;
	private boolean isPacked;
	@Temporal(TemporalType.DATE)
	private Date dateTimeSent;

	public Order() {
	}

	public Order(Customer customer, Date dateTimeOrdered,
			boolean isPacked, Date dateTimeSent) {
		this.customer = customer;
		this.dateTimeOrdered = dateTimeOrdered;
		this.isPacked = isPacked;
		this.dateTimeSent = dateTimeSent;
	}

	public long getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Customer getCustomer() {
		return customer;
	}

	public void setCustomer(Customer customer) {
		this.customer = customer;
	}

	public Date getDateTimeOrdered() {
		return dateTimeOrdered;
	}

	public void setDateTimeOrdered(Date dateTimeOrdered) {
		this.dateTimeOrdered = dateTimeOrdered;
	}

	public boolean isPacked() {
		return isPacked;
	}

	public void setPacked(boolean packed) {
		isPacked = packed;
	}

	public Date getDateTimeSent() {
		return dateTimeSent;
	}

	public void setDateTimeSent(Date dateTimeSent) {
		this.dateTimeSent = dateTimeSent;
	}

	@Override public boolean equals(Object o) {
		if (this == o)
			return true;
		if (!(o instanceof Order))
			return false;
		Order order = (Order) o;
		return id == order.id && isPacked == order.isPacked && Objects.equals(
				customer, order.customer) && Objects.equals(dateTimeOrdered,
				order.dateTimeOrdered) && Objects.equals(dateTimeSent,
				order.dateTimeSent);
	}

	@Override public int hashCode() {
		return Objects.hash(id, customer, dateTimeOrdered, isPacked, dateTimeSent);
	}

	@Override public String toString() {
		return "Order{" + "id=" + id + ", customer=" + customer
				+ ", dateTimeOrdered=" + dateTimeOrdered + ", isPacked=" + isPacked
				+ ", dateTimeSent=" + dateTimeSent + '}';
	}
}
