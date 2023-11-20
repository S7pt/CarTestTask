using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarsCustomizationList" , menuName = "ScriptableObjects/CarsCustomizationList", order = 1)]
public class CarsCustomizationList : ScriptableObject
{
    public List<CarCustomizationData> cars;
}