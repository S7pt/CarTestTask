using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private CarsCustomizationList _carsCustomizationList;

	public CarsCustomizationList CustomizationList => _carsCustomizationList;

    public static GameData Instance;

	private void Start()
	{
		if(Instance != null)
		{
			Destroy(Instance);
		}
		Instance = this;
	}
}
