using Fusion;
using System;
using UnityEngine;

public class CarController : NetworkBehaviour
{
	[SerializeField] private Rigidbody _carRb;
    [SerializeField] private Axle _frontAxle;
    [SerializeField] private Axle _driveAxle;
	[SerializeField] private float _torqueForce;
	[SerializeField] private float _torqueLoss;
	[SerializeField] private float _maxSteerAngle;
	[SerializeField] private float _brakeTorque;

	[Networked] private CarInput.NetworkInputData Input { get; set; }
	private bool _isDrifting;

	public bool IsDrifting => _isDrifting;


	public override void Spawned()
	{
		base.Spawned();
		GameManager.Instance.GameEnded += OnGameEnded;
	}

	public override void Despawned(NetworkRunner runner, bool hasState)
	{
		base.Despawned(runner, hasState);
		GameManager.Instance.GameEnded -= OnGameEnded;
	}

	private void OnGameEnded()
	{
		this.enabled = false;
		HandleBraking(_torqueForce * _brakeTorque);
	}

	public override void FixedUpdateNetwork()
	{
		if(GetInput(out CarInput.NetworkInputData input))
		{
			Input = input;
			HandleInput();
		}
	}

	private void HandleInput()
	{
		float horizontalMovement = Input.movementInput.x;
		float verticalMovement = Input.movementInput.y;
		HandleMovement(verticalMovement);
		float brakeTorque = Input.isBraking ? _brakeTorque : Input.movementInput.y == 0f ? _torqueLoss : 0;
		HandleBraking(brakeTorque);
		HandleSteering(horizontalMovement);
		HandleDrifting(Input.isDrifting, Input.movementInput);
	}

	private void HandleMovement(float input)
	{
		_driveAxle.Rotate(input * _torqueForce);
	}

	private void HandleBraking(float brakeTorque)
	{
		_frontAxle.Brake(brakeTorque);
		_driveAxle.Brake(brakeTorque);
	}

	private void HandleDrifting(bool isDriftingButtonPressed, Vector2 movementInput)
	{
		if (!isDriftingButtonPressed)
		{
			_carRb.constraints = RigidbodyConstraints.None;
			_isDrifting = false;
			return;
		}
		if (movementInput.y != 0 && movementInput.x != 0)
		{
			_carRb.constraints = RigidbodyConstraints.FreezeRotationY;
			_isDrifting = true;
		}
	}

	private void HandleSteering(float input)
	{
		_frontAxle.Steer(input * _maxSteerAngle);
	}
}
