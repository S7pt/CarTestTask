using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelCollider;
    [SerializeField] private GameObject _wheelVisuals;

    public WheelCollider WheelCollider => _wheelCollider;

    public void Rotate(float torque)
	{
        _wheelCollider.motorTorque = torque;
	}

    public void Steer(float angle)
	{
        _wheelCollider.steerAngle = Mathf.Lerp(_wheelCollider.steerAngle, angle, 0.6f);
	}

    public void Brake(float brakeForce)
	{
        _wheelCollider.brakeTorque = brakeForce;
	}
}
