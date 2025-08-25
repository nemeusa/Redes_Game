using Fusion;
using UnityEngine;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] NetworkPrefabRef _playerPrefabs;

    private void Update()
    {
       // PlayerJoined(a);
    }
    public void PlayerJoined(PlayerRef player)
   {
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(_playerPrefabs, new Vector3(0,1,0), Quaternion.identity);
        }
   }
}
