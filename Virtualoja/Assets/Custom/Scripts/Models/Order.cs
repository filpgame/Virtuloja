using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
	public List<OrderItem> Items {
		get;
		set;
	}

	public Order()
	{
		Items = new List<OrderItem> ();
	}

	public class OrderItem
	{
		public Product Product {
			get;
			set;
		}

		public int Quantity {
			get;
			set;
		}
	}
}
