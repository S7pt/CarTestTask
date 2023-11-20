using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarCustomizationData" , menuName = "ScriptableObjects/CustomizationData", order = 0)]
public class CarCustomizationData : ScriptableObject
{
    public CarColorData _carBody;
    public List<Color> _bodyColors;
    public List<Color> _detailsColors;
    public List<AccessoriesCategory> _categories;
}

[System.Serializable]
public struct AccessoriesCategory
{
    public string name;
    public List<Accessory> accessories;
}

[System.Serializable]
public struct Accessory
{
    public string name;
    public GameObject accessoryObject;
}
