using Fusion;
using UnityEngine;

public class SpawnArms : NetworkBehaviour
{
    [SerializeField] NetworkPrefabRef[] _armsPrefabs;
    [SerializeField] Transform[] _spawnPointsArms;
    int _armsCount = 0;

    public override void Spawned()
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        Debug.Log("FUNCIONAAA");
        if (HasStateAuthority)
        {
            spawnWeapons();
        }
    }

    public void Update()
    {
        spawnWeapons();
    }

    public void spawnWeapons()
    {
        if (_armsCount > _spawnPointsArms.Length) return;

        var indexSpawns = Random.Range(0, _spawnPointsArms.Length + 1);
        var spawnPoints = _spawnPointsArms[indexSpawns];

        var indexArms = Random.Range(0, _armsPrefabs.Length + 1);
        Runner.Spawn(_armsPrefabs[indexArms], spawnPoints.position, spawnPoints.rotation);
        Debug.Log("SPAWN ARM");
        _armsCount++;
    }
}
