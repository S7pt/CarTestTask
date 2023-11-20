using TMPro;
using UnityEngine;

public class PlayerMoneyController : MonoBehaviour
{
	private const string MONEY = "Money";
	private const string MONEY_CHANGE = "MoneyChange";
	[SerializeField] private TMP_Text _moneyText;
	private int _currentMoney;

	public int Money => _currentMoney;

	private void Awake()
	{
		int moneyChange = PlayerPrefs.GetInt(MONEY_CHANGE);
		_currentMoney = PlayerPrefs.GetInt(MONEY);
		ChangeMoney(moneyChange);
		PlayerPrefs.SetInt(MONEY_CHANGE, 0);
		UpdateMoneyText();
	}

	private void UpdateMoneyText()
	{
		_moneyText.text = _currentMoney.ToString();
	}

	private void ChangeMoney(int moneyChange)
	{
		_currentMoney += moneyChange;
	}

	private void SaveMoney()
	{
		PlayerPrefs.SetInt(MONEY, _currentMoney);
	}

	private void OnDestroy()
	{
		SaveMoney();
	}
}
