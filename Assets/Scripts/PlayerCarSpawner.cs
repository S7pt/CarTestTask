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

	public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
	{
		//throw new NotImplementedException();
	}

	public void OnInput(NetworkRunner runner, NetworkInput input)
	{
		//throw new NotImplementedException();
	}

	public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
	{
		//throw new NotImplementedException();
	}

	public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
	{
		Debug.Log("Runner shutdown");
	}

	public void OnConnectedToServer(NetworkRunner runner)
	{
		//throw new NotImplementedException();
	}

	public void OnDisconnectedFromServer(NetworkRunner runner)
	{
		//throw new NotImplementedException();
	}

	public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
	{
		//throw new NotImplementedException();
	}

	public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
	{
		Debug.Log("ConnectionFailed");
	}

	public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
	{
		//throw new NotImplementedException();
	}

	public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
	{
		//throw new NotImplementedException();
	}

	public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
	{
		//throw new NotImplementedException();
	}

	public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
	{
		//throw new NotImplementedException();
	}

	public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
	{
		//throw new NotImplementedException();
	}

	public void OnSceneLoadDone(NetworkRunner runner)
	{
		//throw new NotImplementedException();
	}

	public void OnSceneLoadStart(NetworkRunner runner)
	{
		//throw new NotImplementedException();
	}
}
