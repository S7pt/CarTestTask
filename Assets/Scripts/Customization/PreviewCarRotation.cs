using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCarRotation : MonoBehaviour
{
	[SerializeField] private float _rotationSpeed;
	private Vector3 _defaultRotation;
	private bool _canRotate;

	private void Awake()
	{
		_defaultRotation = transform.eulerAngles;
	}

	private void Update()
	{
		HandleRotation();
	}

	private void OnDisable()
	{
		_canRotate = false;
		ResetRotation();
	}

	private void OnEnable()
	{
		_canRotate = true;
	}

	private void HandleRotation()
	{
		if (!_canRotate)
		{
			return;
		}
		transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime;
	}

	public void ResetRotation()
	{
		transform.eulerAngles = _defaultRotation;
	}
}
