using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
	public List<OrderItem> Items;

	public Order()
	{
		Items = new List<OrderItem> ();
	}

	[System.Serializable]
	public class OrderItem
	{
		public Product Product;

		public int Quantity;
	}
}
