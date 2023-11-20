using System.Collections.Generic;
using UnityEngine;

public class Axle : MonoBehaviour
{
    [SerializeField] private List<Wheel> _wheels;
	public List<Wheel> AxleWheels => _wheels;

	public void Rotate(float torque)
	{
		foreach (Wheel wheel in _wheels)
		{
			wheel.Rotate(torque);
		}
	}

    public void Steer(float angle)
	{
		foreach(Wheel wheel in _wheels)
		{
			wheel.Steer(angle);
		}
	}

	public void Brake(float brakeForce)
	{
		foreach (Wheel wheel in _wheels)
		{
			wheel.Brake(brakeForce);
		}
	}
}
