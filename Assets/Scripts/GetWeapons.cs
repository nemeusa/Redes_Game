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
        
       // if (!HasInputAuthority) return;

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

                Runner.Despawn(arms.Object);

                foreach (var a in allArms) if (a.weaponsType == arms.weaponsType) currentArms = a; 


                if (HasStateAuthority)
                    RpcToggleChild();


                gettinArm = true;

                //break;
            }
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RpcToggleChild()
    {
        currentArms.childArm.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        if (getPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(getPoint.position, getRange);
    }

}
