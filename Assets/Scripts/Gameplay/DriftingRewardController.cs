using UnityEngine;

public class DriftingRewardController : MonoBehaviour
{
	private const string MONEY_CHANGE = "MoneyChange";
	[SerializeField] private CarController _controller;
	private int _points;

	public int Points => _points;

	private void Start()
	{
		GameManager.Instance.GameEnded += OnGameEnded;
	}

	private void OnGameEnded()
	{
		PlayerPrefs.SetInt(MONEY_CHANGE, (int)(_points * 0.05));
	}

	private void Update()
	{
		if (_controller.IsDrifting)
		{
			_points++;
		}
	}
}
