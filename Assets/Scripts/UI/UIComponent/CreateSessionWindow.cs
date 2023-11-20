using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateSessionWindow : UIWindow
{
	[SerializeField] private GameLauncher _launcher;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private TMP_InputField _sessionInputField;

    private string _sessionName;

	private void Awake()
	{
		_confirmButton.interactable = false;
		_backButton.onClick.AddListener(GoBack);
		_confirmButton.onClick.AddListener(OnConfirmButtonClicked);
		_sessionInputField.onValueChanged.AddListener(OnSessionNameChanged);
	}

	private void OnSessionNameChanged(string name)
	{
		_sessionName = name;
		_confirmButton.interactable = !string.IsNullOrEmpty(name);
	}

	private void OnConfirmButtonClicked()
	{
		_launcher.JoinOrCreateLobby(_sessionName, GameMode.Host);
	}
}
