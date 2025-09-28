using Fusion;
using UnityEngine;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] NetworkPrefabRef _playerPrefabs;

    [SerializeField] Transform[] _spawnPoints;

    public void PlayerJoined(PlayerRef player)
   {
        if (player == Runner.LocalPlayer)
        {
            if (Runner.SessionInfo.PlayerCount > _spawnPoints.Length) return;

            var spawnPoint = _spawnPoints[Runner.SessionInfo.PlayerCount - 1];

            Runner.Spawn(_playerPrefabs, spawnPoint.position, spawnPoint.rotation);

        }
   }
}
