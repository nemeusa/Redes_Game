using Fusion;
using UnityEngine;

public class Arms : NetworkBehaviour
{
    public WeaponsType weaponsType;
    public GameObject childArm;
}

public enum WeaponsType
{
   Masa,
   Chair
}
