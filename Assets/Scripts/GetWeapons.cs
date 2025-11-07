using Fusion;
using UnityEngine;

public class GetWeapons : NetworkBehaviour
{
    [Header("Ajustes de ataque")]
    public float getRange = 1.5f;      
    public float getRate = 1f;         
    public LayerMask objectLayer;          

    [Header("Referencias")]
    public Transform getPoint;        
    public Arms currentArms;

    private WeaponsType weaponsType;

    bool gettinArm;

    [SerializeField] Arms[] allArms;


    public override void FixedUpdateNetwork()
    {
        
        //if (!HasInputAuthority) return;

        if (Input.GetKeyDown(KeyCode.E) && !gettinArm)
        {
            Debug.Log("Press E");
            GetObjects2();
        }

    }

    void GetObjects2()
    {
        Collider[] getArms = Physics.OverlapSphere(getPoint.position, getRange, objectLayer); // PONER COLLIDER DE PHOTON

        foreach (Collider armsCol in getArms)
        {
            Arms arms = armsCol.GetComponent<Arms>();
            if (arms != null)
            {
                weaponsType = arms.weaponsType;

                RpcRequestDespawn(arms._object.Id);

                if (HasStateAuthority)
                    RpcToggleChild((int)weaponsType);

                gettinArm = true;
            }
        }
    }


    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RpcToggleChild(int type)
    {
        foreach (var a in allArms)
        {
            if ((int)a.weaponsType == type)
            {
                a.childArm.SetActive(true);
                currentArms = a;
                break;
            }
        }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RpcRequestDespawn(NetworkId id)
    {
        if (Runner.TryFindObject(id, out NetworkObject netObj))
            Runner.Despawn(netObj);
    }

    private void OnDrawGizmosSelected()
    {
        if (getPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(getPoint.position, getRange);
    }

}
