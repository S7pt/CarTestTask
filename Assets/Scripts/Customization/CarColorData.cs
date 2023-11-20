using UnityEngine;

public class CarColorData : MonoBehaviour
{
    [SerializeField] private Material _bodyMaterial;
    [SerializeField] private Material _detailsMaterial;

    public Material BodyMaterial => _bodyMaterial;
    public Material DetailsMaterial => _detailsMaterial;
}
