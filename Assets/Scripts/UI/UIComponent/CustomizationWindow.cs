using UnityEngine;
using UnityEngine.UI;

public class CustomizationWindow : UIWindow
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _backButton;
	[SerializeField] private Button _confirmButton;
	[SerializeField] private CarCustomizationManager _customizationManager;

	private void Start()
	{
		_nextButton.onClick.AddListener(OnNextButtonClicked);
		_previousButton.onClick.AddListener(OnPreviousButtonClicked);
		_confirmButton.onClick.AddListener(OnConfirmButtonClicked);
		_backButton.onClick.AddListener(GoBack);
	}

	private void OnConfirmButtonClicked()
	{
		_customizationManager.SavePreferences();
	}

	private void OnPreviousButtonClicked()
	{
		_customizationManager.ChangeCarPreview(-1);
	}

	private void OnNextButtonClicked()
	{
		_customizationManager.ChangeCarPreview(1);
	}


}
