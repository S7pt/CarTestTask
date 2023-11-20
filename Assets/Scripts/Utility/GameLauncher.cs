using Fusion;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
	[SerializeField] private NetworkRunner _runnerPrefab;
	[SerializeField] private NetworkedCar _carPrefab;
	private NetworkRunner _runner;

	public void JoinOrCreateLobby(string sessionName, GameMode mode)
	{
		if (_runner != null)
		{
			_runner.Shutdown();
		}
		_runner = Instantiate(_runnerPrefab);
		DontDestroyOnLoad(_runner);
		_runner.StartGame(new StartGameArgs
		{
			GameMode = mode,
			SessionName = sessionName,
			Scene = 1
		});
		;
	}
}
