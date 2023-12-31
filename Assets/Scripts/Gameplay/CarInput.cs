using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarInput : NetworkBehaviour, INetworkRunnerCallbacks
{
    public struct NetworkInputData : INetworkInput
	{
        public Vector2 movementInput;
        public NetworkBool isBraking;
		public NetworkBool isDrifting;
	}

	public override void Spawned()
	{
		base.Spawned();
		Runner.AddCallbacks(this);
	}

	public override void Despawned(NetworkRunner runner, bool hasState)
	{
		base.Despawned(runner, hasState);
		Runner.RemoveCallbacks(this);
	}

	public void OnInput(NetworkRunner runner, NetworkInput input) 
	{
		NetworkInputData playerInput = new NetworkInputData();
		playerInput.movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		playerInput.isBraking = Input.GetKey(KeyCode.Space);
		playerInput.isDrifting = Input.GetKey(KeyCode.E);
		input.Set(playerInput);
	}

	public void OnPlayerJoined(NetworkRunner runner, PlayerRef player){}

	public void OnPlayerLeft(NetworkRunner runner, PlayerRef player){}

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
