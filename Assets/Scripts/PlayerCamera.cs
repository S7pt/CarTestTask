using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    
    public void Follow(NetworkedCar car)
	{
        _camera.LookAt = car.transform;
        _camera.Follow = car.transform;
	}
}
