using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    [SerializeField] private Rigidbody _carRB;
    [SerializeField] private Wheel _rightWheel;
    [SerializeField] private Wheel _leftWheel;
    [SerializeField] float _antiRoll = 5000.0f;

    private void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;
    
        var groundedL = _leftWheel.WheelCollider.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-_leftWheel.WheelCollider.transform.InverseTransformPoint(hit.point).y - _leftWheel.WheelCollider.radius) / _leftWheel.WheelCollider.suspensionDistance;
    
        var groundedR = _rightWheel.WheelCollider.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-_rightWheel.WheelCollider.transform.InverseTransformPoint(hit.point).y - _rightWheel.WheelCollider.radius) / _rightWheel.WheelCollider.suspensionDistance;
    
        float antiRollForce = (travelL - travelR) * _antiRoll;
    
        if (groundedL)
            _carRB.AddForceAtPosition(_leftWheel.WheelCollider.transform.up * -antiRollForce,
                   _leftWheel.WheelCollider.transform.position);
        if (groundedR)
            _carRB.AddForceAtPosition(_rightWheel.WheelCollider.transform.up * antiRollForce,
                   _rightWheel.WheelCollider.transform.position);
    }
}
