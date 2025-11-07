using Fusion;
using UnityEngine;

public class Arms : NetworkBehaviour
{
    public WeaponsType weaponsType;
    public GameObject childArm;
    public NetworkObject _object;

    public override void Spawned()
    {
        _object = GetComponent<NetworkObject>();
    }
}

public enum WeaponsType
{
   Masa,
   Chair
}
