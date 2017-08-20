using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRColliderButton : MonoBehaviour, IVRButton
{
	[SerializeField]
	private float _activationTime;

	private float _currentActivationTime;

	[SerializeField]
	private Animator _animator;

	private bool _isFocused;

	[SerializeField]
	private GameObject _onClickTarget;

	[SerializeField]
	private string _onClickMethod;

	[SerializeField]
	private bool _multipleHits = false;

	private bool _canSendOnClick = true;

	public void Defocus()
	{
		_isFocused = false;
		_animator.SetBool ("Down", false);

		_canSendOnClick = true;
	}

	public void Focus()
	{
		_isFocused = true;
		_animator.SetBool ("Down", true);

		_currentActivationTime = 0;
	}

	void Update()
	{
		if (_isFocused && (_canSendOnClick || _multipleHits))
		{
			_currentActivationTime += Time.deltaTime;

			if (_currentActivationTime >= _activationTime) {

				if (_onClickTarget != null) {
					_onClickTarget.SendMessage (_onClickMethod);
					_canSendOnClick = false;
					_currentActivationTime = 0;
				}
			}
		}
	}
}
