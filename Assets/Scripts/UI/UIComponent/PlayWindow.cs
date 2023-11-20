using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWindow : UIWindow
{
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _joinButton;
	[SerializeField] private Button _backButton;
	[SerializeField] private CreateSessionWindow _hostWindow;
	[SerializeField] private JoinSessionWindow _joinWindow;

	private void Start()
	{
		_backButton.onClick.AddListener(GoBack);
		_hostButton.onClick.AddListener(OnHostButtonClicked);
		_joinButton.onClick.AddListener(OnJoinButtonClicked);
	}

	private void OnHostButtonClicked()
	{
		UIStack.Instance.Push(_hostWindow);
		Disable();
	}

	private void OnJoinButtonClicked()
	{
		UIStack.Instance.Push(_joinWindow);
		Disable();
	}
}
