/*============================================================================== 
 * Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GazeRay : MonoBehaviour
{
	private IVRButton _lastHit;

    #region MONOBEHAVIOUR_METHODS
    void Update()
    {
        // Check if the Head gaze direction is intersecting any of the ViewTriggers
        RaycastHit hit;
        Ray cameraGaze = new Ray(this.transform.position, this.transform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);

		if (hit.collider == null) {
			if (_lastHit != null)
				_lastHit.Defocus ();
			_lastHit = null;
		}
		else {
			Debug.Log (hit.collider.name);
			var currentHit = hit.collider.GetComponent<IVRButton> ();

			if (currentHit != null) {
				if (_lastHit == null) {

					currentHit.Focus ();
				}
				else if (_lastHit != currentHit) {
					_lastHit.Defocus ();
					currentHit.Focus ();
				}
			}

			_lastHit = currentHit;
		}
    }
    #endregion // MONOBEHAVIOUR_METHODS
}

