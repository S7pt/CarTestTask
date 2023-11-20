using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : UIWindow
{
    [SerializeField] private Button _playButton;
	[SerializeField] private Button _customizeButton;
	[SerializeField] private UIWindow _playWindow;
	[SerializeField] private UIWindow _customizationWindow;

	private void Start()
	{
		UIStack.Instance.Push(this);
		_playButton.onClick.AddListener(OnPlayButtonClicked);
		_customizeButton.onClick.AddListener(OnCustomizeButtonClicked);
	}

	private void OnCustomizeButtonClicked()
	{
		UIStack.Instance.Push(_customizationWindow);
		Disable();
	}

	private void OnPlayButtonClicked()
	{
		UIStack.Instance.Push(_playWindow);
		Disable();
	}
}
