using System.Collections.Generic;
using UnityEngine;

public class CarCustomizationManager : MonoBehaviour
{
    [SerializeField] private PlayerPreferences _preferences;

    private CarCustomizationData _customizationData;
    private GameObject _currentPreview;
    private List<int> _customizationIds;
    private int _currentCarId;
    private int _maxCars;

    public List<AccessoriesCategory> AccessoriesCategories => _customizationData._categories;

	private void Start()
	{
        _maxCars = GameData.Instance.CustomizationList.cars.Count;
        _currentCarId = _preferences.Id;
        _customizationIds = _preferences.GetPreferencesIds();
        SetupCarPreview(_currentCarId);
	}

    public void ChangeCarPreview(int idChange)
	{
        _currentCarId = (_currentCarId + idChange) % _maxCars;
        if (_currentCarId < 0)
		{
            _currentCarId = _maxCars - 1;
        }
        ClearPreview();
        ResetIdList(_currentCarId);
        SetupCarPreview(_currentCarId);
	}

    public void SavePreferences()
	{
        _preferences.SetData(_currentCarId, _customizationIds);
	}

    public void ChangePreference(int id, int value)
    {
        _customizationIds[id] = value;
    }

    private void SetupCarPreview(int id)
	{
        _customizationData = GameData.Instance.CustomizationList.cars[id];
        CarColorData data = Instantiate(_customizationData._carBody, transform);
        _currentPreview = data.gameObject;
        data.BodyMaterial.color = _customizationData._bodyColors[_customizationIds[0]];
        data.DetailsMaterial.color = _customizationData._detailsColors[_customizationIds[1]];
        for(int i = 0, j = 2; i < _customizationData._categories.Count || j < _customizationIds.Count; i++, j++)
		{
            Instantiate(_customizationData._categories[i].accessories[j].accessoryObject, _currentPreview.transform);
		}
	}


    private void ClearPreview()
	{
        Destroy(_currentPreview);
	}

    private void ResetIdList(int id)
	{
        int idCount = GameData.Instance.CustomizationList.cars[id]._categories.Count + 2;
        _customizationIds = new List<int>();
        for(int i = 0; i < idCount; i++)
		{
            _customizationIds.Add(0);
		}
    }

}
