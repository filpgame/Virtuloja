using UnityEngine;
using System;

public class ProductTrackableHandler : MonoBehaviour,
Vuforia.ITrackableEventHandler
{
	private Vuforia.TrackableBehaviour mTrackableBehaviour;

	public float TimeToShowAgain = 0;

	public Action OnTrackingFounded, OnTrackingLosted;

	void Start()
	{
		mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	void Update()
	{
		if (TimeToShowAgain > 0)
			TimeToShowAgain -= Time.deltaTime;


	}

	#region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		Vuforia.TrackableBehaviour.Status previousStatus,
		Vuforia.TrackableBehaviour.Status newStatus)
	{
		if (newStatus == Vuforia.TrackableBehaviour.Status.DETECTED ||
			newStatus == Vuforia.TrackableBehaviour.Status.TRACKED ||
			newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			if(TimeToShowAgain <= 0)
				OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS



	#region PRIVATE_METHODS


	public void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		Canvas[] canvasComponents = GetComponentsInChildren<Canvas> (true);

		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}

		// Enable canvas:
		foreach (Canvas component in canvasComponents)
		{
			component.enabled = true;
		}

		if (OnTrackingFounded != null)
			OnTrackingFounded.Invoke ();
	}


	public void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		Canvas[] canvasComponents = GetComponentsInChildren<Canvas> (true);

		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}

		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}

		// Disable canvas:
		foreach (Canvas component in canvasComponents)
		{
			component.enabled = false;
		}

		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

		if (OnTrackingLosted != null)
			OnTrackingLosted.Invoke ();
	}

	#endregion // PRIVATE_METHODS
}
