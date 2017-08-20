using UnityEngine;
using System.Collections;

public class CheckInView : MonoBehaviour
{
	[SerializeField]
	private GameObject _loadingObject;

	public void CheckIn()
	{
		Debug.Log ("loading");
		_loadingObject.SetActive (true);

		StartCoroutine(ApiService.Instance.CheckIn (OrderManager.Instance.User.Id, () => { _loadingObject.SetActive(false); Debug.Log ("cabo");}));

		OrderManager.Instance.CheckIn ();
	}
}
