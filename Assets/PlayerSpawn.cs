using Fusion;
using UnityEngine;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] NetworkPrefabRef _playerPrefabs;

    [SerializeField] Transform[] _spawnPoints;

    private void Update()
    {
       // PlayerJoined(a);
    }
    public void PlayerJoined(PlayerRef player)
   {
        if (player == Runner.LocalPlayer)
        {
            if (Runner.SessionInfo.PlayerCount > _spawnPoints.Length) return;

            var spawnPoint = _spawnPoints[Runner.SessionInfo.PlayerCount - 1];

            Runner.Spawn(_playerPrefabs, new Vector3(0,1,0), Quaternion.identity);

        }
   }
}
