using UnityEngine;
using System.Collections;

public class CheckoutView : MonoBehaviour {

	public UnityEngine.UI.Text items, total;

	public CheckoutTrackableHandler Trackable;

	public GameObject VisaCard, MasterCard;
	public Transform Pos;

	public GameObject Pay, FinishObject;
	// Use this for initialization
	void Start () {

		Trackable.OnTrackingFounded += () => {
			items.text = string.Empty;

			double totalAmount=0;
			foreach (var i in OrderManager.Instance.Order.Items) {

				double totalItem = (i.Product.Value * i.Quantity);
				items.text += i.Product.Description + "   x " + i.Quantity + "   R$" + totalItem.ToString ("#.##") + "\n\n";

				totalAmount += totalItem;
			}

			total.text = "R$ " + totalAmount.ToString("#.##");
		};
	}

	public void Visa () {
		iTween.MoveTo (VisaCard, Pos.position, 0.5f);
		MasterCard.SetActive (false);
		Pay.SetActive (true);
	}

	public void Master()
	{
		iTween.MoveTo (MasterCard, Pos.position, 0.5f);
		VisaCard.SetActive (false);
		Pay.SetActive (true);
	}

	public void Finish()
	{
		Pay.SetActive (false);
		FinishObject.SetActive (true);
	}
}
