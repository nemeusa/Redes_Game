using System.Collections;
using System.Collections.Generic;
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
    public Animator animator;
    public Arms currentArms;

    private WeaponsType weaponsType;

    bool gettinArm;

    [SerializeField] private SwitchObject switchObject; // arrastrá aquí el objeto en el Inspector

    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject maza;

    public Arms chairInScene;
    public Arms mazaInScene;

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
        Collider[] getArms = Physics.OverlapSphere(getPoint.position, getRange, objectLayer);

        foreach (Collider armsCol in getArms)
        {
            Arms arms = armsCol.GetComponent<Arms>();
            if (arms != null)
            {
                arms.inHand = true;


                //if (arms.weaponsType == WeaponsType.Masa)
                //{
                //    Runner.Despawn(mazaInScene.Object);
                //    switchObject.ToggleChildMaza();
                //    Debug.Log("agarra masa");
                //}
                //else if (arms.weaponsType == WeaponsType.Chair)
                //{
                //    Runner.Despawn(chairInScene.Object);
                //    switchObject.ToggleChildChair();
                //    Debug.Log("Agarra silla");
                //}


                //if (arms.weaponsType == WeaponsType.Masa)
                //{
                //    Runner.Despawn(mazaInScene.Object);
                //    Debug.Log("agarra masa");
                //}
                //else if (arms.weaponsType == WeaponsType.Chair)
                //{
                //    Runner.Despawn(chairInScene.Object);
                //    Debug.Log("Agarra silla");
                //}

                var currentArm = ChooseArm(arms);

             
                Runner.Despawn(arms.Object);

                currentArm.GetComponent<Arms>().childArm.SetActive(true);

                switchObject.ToggleChild(currentArm.GetComponent<Arms>().childArm);

                gettinArm = true;
                

                break;
            }
        }
    }

    GameObject ChooseArm(Arms arm)
    {
        GameObject actuallyArm = allArms[0].gameObject;
        for (int i = 0; i < allArms.Length; i++)
        {
            if (allArms[i].weaponsType == arm.weaponsType)
            {
                Debug.Log("agarraste " + allArms[i].weaponsType);
                actuallyArm = allArms[i].gameObject;
            }
        }
        return actuallyArm;
    }

    private void OnDrawGizmosSelected()
    {
        if (getPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(getPoint.position, getRange);
    }


}
