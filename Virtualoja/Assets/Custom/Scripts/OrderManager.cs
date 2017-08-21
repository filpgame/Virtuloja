using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
	public User User {
		get;
		set;
	}

	public Order Order;

	private static OrderManager _instance;
	public static OrderManager Instance
	{
		get {
			return _instance;
		}
	}

	void Start()
	{
		_instance = this;
		User = new User ();
		User.Id = "12345678";
		User.MyProfile = new User.Profile ();
		User.MyProfile.Name = "Lucas Amorim";
	}

	public void CheckIn()
	{
		Order = new Order ();
	}
}
