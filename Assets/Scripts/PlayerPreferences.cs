using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
	private const string ID = "Id";
	private const string MAIN_COLOR = "MainColor";
	private const string DETAIL_COLOR = "DetailColor";

	private CarCustomizationData _playerPreferenceData;
	private int _id = 0;
	private bool _isEmpty;

	public int Id => _id;

	private void Awake()
	{
		_isEmpty = !PlayerPrefs.HasKey(ID);
		if (!_isEmpty)
		{
			_id = PlayerPrefs.GetInt(ID);
		}
		_playerPreferenceData = GameData.Instance.CustomizationList.cars[_id];

	}

	public List<int> GetPreferencesIds()
	{
		int idsCount = _playerPreferenceData._categories.Count + 2;
		List<int> preferenceIds = new List<int>(idsCount);
		if (_isEmpty)
		{
			for(int i = 0; i < idsCount; i++)
			{
				preferenceIds.Add(0);
			}
			return preferenceIds;
		}
		preferenceIds.Add(PlayerPrefs.GetInt(MAIN_COLOR));
		preferenceIds.Add(PlayerPrefs.GetInt(DETAIL_COLOR));
		foreach(AccessoriesCategory category in _playerPreferenceData._categories)
		{
			preferenceIds.Add(PlayerPrefs.GetInt(category.name));
		}
		return preferenceIds;
	}

	public void SetData(int id, List<int> preferences)
	{
		CarCustomizationData data = GameData.Instance.CustomizationList.cars[id];
		if(preferences == null)
		{
			throw new Exception("Id list is empty");
		}
		PlayerPrefs.SetInt(ID, id);
		PlayerPrefs.SetInt(MAIN_COLOR, preferences[0]);
		PlayerPrefs.SetInt(DETAIL_COLOR, preferences[1]);
		for(int i = 2; i < data._categories.Count; i++)
		{
			PlayerPrefs.SetInt(data._categories[i].name, preferences[1]);
		}
	}
}
