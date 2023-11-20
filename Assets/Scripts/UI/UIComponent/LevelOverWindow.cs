using UnityEngine;
using UnityEngine.UI;

public class LevelOverWindow : UIWindow
{
    [SerializeField] private Button _exitButton;

	private void OnEnable()
	{
		_exitButton.onClick.AddListener(OnExitButtonClicked);
	}

	private void OnDisable()
	{
		_exitButton.onClick.RemoveListener(OnExitButtonClicked);
	}

	private void OnExitButtonClicked()
	{
		Runner.SetActiveScene(0);
	}
}
