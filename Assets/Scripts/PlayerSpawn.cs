using Fusion;
using System.Linq;
using UnityEngine;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] NetworkPrefabRef _playerPrefabs;

    [SerializeField] Transform[] _spawnPoints;

    [SerializeField] Camera _camera;

    [SerializeField] NetworkPrefabRef[] _armsPrefabs;
    [SerializeField] Transform[] _spawnPointsArms;
    int _armsCount = 0;

    public void PlayerJoined(PlayerRef player)
   {
        if (player == Runner.LocalPlayer)
        {
            if (Runner.SessionInfo.PlayerCount > _spawnPoints.Length) return;

            var spawnPoint = _spawnPoints[Runner.SessionInfo.PlayerCount - 1];

            var client = Runner.Spawn(_playerPrefabs, spawnPoint.position, spawnPoint.rotation);

            client.GetComponent<PlayerController>().cameraTransform = transform;
        }
   }
}
