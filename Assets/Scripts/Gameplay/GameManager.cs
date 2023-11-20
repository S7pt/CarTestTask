using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using TMPro;

public class GameManager : NetworkBehaviour, INetworkRunnerCallbacks
{
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private GameObject _gameEndMenu;
	[Networked] private float RemainingSeconds { get; set; }
	[Networked] private TickTimer LevelTimer { get; set; }

	public static GameManager Instance;

	public event Action GameEnded;

	public override void Spawned()
	{
		if(Instance != null)
		{
			Destroy(Instance);
		}
		Instance = this;
		Runner.AddCallbacks(this);
	}

	public override void FixedUpdateNetwork()
	{
		base.FixedUpdateNetwork();
		if (LevelTimer.IsRunning)
		{
			RPC_HandleTimer();
		}

	}

	public override void Despawned(NetworkRunner runner, bool hasState)
	{
		base.Despawned(runner, hasState);
		runner.RemoveCallbacks(this);
	}

	[Rpc(RpcSources.StateAuthority,RpcTargets.All)]
	private void RPC_HandleTimer()
	{
		RemainingSeconds = (float)LevelTimer.RemainingTime(Runner);
		_timerText.text = $"{(int)(RemainingSeconds / 60)}:{(int)(RemainingSeconds % 60)}";
		if (LevelTimer.Expired(Runner))
		{
			_gameEndMenu.SetActive(true);
			GameEnded?.Invoke();
		}
	}

	public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
	{
		if (!LevelTimer.IsRunning && runner.IsServer)
		{
			LevelTimer = TickTimer.CreateFromSeconds(runner, 120);
		}
	}

	public void OnConnectedToServer(NetworkRunner runner) { }

	public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }

	public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }

	public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }

	public void OnDisconnectedFromServer(NetworkRunner runner) { }

	public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }

	public void OnInput(NetworkRunner runner, NetworkInput input) { }

	public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }

	public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }

	public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }

	public void OnSceneLoadDone(NetworkRunner runner) { }

	public void OnSceneLoadStart(NetworkRunner runner) { }

	public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }

	public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }

	public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
}
