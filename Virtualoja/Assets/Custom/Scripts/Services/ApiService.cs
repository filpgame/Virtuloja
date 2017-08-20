using UnityEngine;
using System.Collections;
using System;

public class ApiService : MonoBehaviour
{
	private static ApiService _instance;

	private const string _baseUrl = "http://192.168.36.204:8000/";

	public static ApiService Instance
	{
		get {
			return _instance;
		}
	}

	void Start()
	{
		_instance = this;
	}

	public IEnumerator CheckIn(string id, Action callback)
	{
		var bodyData = "{}";
		var postData = System.Text.Encoding.UTF8.GetBytes(bodyData);
		var www = new WWW (_baseUrl + string.Format ("checkin/{0}", id), postData);
		yield return www;

		if (callback != null)
			callback.Invoke ();

		Debug.Log (www.error);
	}

	public IEnumerator GetProduct(string globalId, Action<Product> callback)
	{
		yield return new WWW (_baseUrl + string.Format("productGlobalId/{0}", globalId));

		callback.Invoke (new Product (){ ID="1", GlobalID=1, Value= 10.00, Description= "Nada nada nada nada.."});
	}
}
