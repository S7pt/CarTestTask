using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class PlayerCarSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
	[SerializeField] private NetworkedCar _playerPrefab;
	[SerializeField] private NetworkRunner _runner;

	private void Start()
	{
		if(_runner == null)
		{
			_runner = GetComponent<NetworkRunner>();
		}
	}

	public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
	{
		if (runner.IsServer)
		{
			runner.Spawn(_playerPrefab, Vector3.up * 3, Quaternion.identity, player);
		}
	}

	public void OnPlayerLeft(NetworkRunner runner, PlayerRef player){}

	public void OnInput(NetworkRunner runner, NetworkInput input){}

	public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input){}

	public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason){}

	public void OnConnectedToServer(NetworkRunner runner){}

	public void OnDisconnectedFromServer(NetworkRunner runner){}

	public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token){}

	public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason){}

	public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message){}

	public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList){}

	public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data){}

	public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken){}

	public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data){}

	public void OnSceneLoadDone(NetworkRunner runner){}

	public void OnSceneLoadStart(NetworkRunner runner){}
}
