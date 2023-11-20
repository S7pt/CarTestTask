using Fusion;
using UnityEngine;

public class NetworkedCar : NetworkBehaviour, IPlayerLeft
{
    public static NetworkedCar LocalInstance;

	public override void Spawned()
	{
		base.Spawned();

		if (Object.HasInputAuthority)
		{
			if(LocalInstance != null)
			{
				Destroy(LocalInstance);
			}
			LocalInstance = this;
			Camera.main.GetComponent<PlayerCamera>().Follow(this);
		}
	}

	public void PlayerLeft(PlayerRef player)
	{
		if(player == Object.InputAuthority)
		{
			Runner.Despawn(Object);
		}
	}
}
