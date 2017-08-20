using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
	public string GlobalId;

	public Product Product {
		get;
		set;
	}

	private int _selectedQuantity;
	private int SelectedQuantity
	{
		get { return _selectedQuantity; }
		set {

			_selectedQuantity = Mathf.Max(0, value);
			_quantityText.text = _selectedQuantity.ToString();
			_totalAmountText.text = "R$ " + (Product.Value * _selectedQuantity).ToString("#.##");

		}
	}

	[SerializeField]
	private Vuforia.DefaultTrackableEventHandler _trackableEventHandler;

	[SerializeField]
	private Text _nameText, _quantityText, _totalAmountText;

	void Start()
	{
		_trackableEventHandler.OnTrackingFounded += () =>
		{
			StartCoroutine(ApiService.Instance.GetProduct(GlobalId, SetProduct));
		};
	}

	private void SetProduct(Product product)
	{
		Product = product;
		_nameText.text = product.Description;
		SelectedQuantity = 1;
	}

	public void AddProduct()
	{
		SelectedQuantity++;
	}

	public void RemoveProduct()
	{
		SelectedQuantity--;
	}

	public void Confirm()
	{
	}
}
