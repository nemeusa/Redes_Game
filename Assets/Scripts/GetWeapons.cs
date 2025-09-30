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
                currentArms = arms;
                currentArms.inHand = true;

                //arms.transform.SetParent(getPoint);

                if (currentArms.weaponsType == WeaponsType.Masa)
                {
                    Runner.Despawn(mazaInScene.Object);
                    switchObject.ToggleChildMaza();
                    Debug.Log("agarra masa");

                    //maza.SetActive(true);
                    //arms.transform.localPosition = new Vector3(0.76f, 0.83f, 0.37f);
                    //arms.transform.localRotation = Quaternion.Euler(44.4f, 0, 0);
                }
                else
                {
                    Runner.Despawn(chairInScene.Object);
                    switchObject.ToggleChildChair();
                    Debug.Log("Agarra silla");

                    //chair.SetActive(true);
                    //arms.transform.localPosition = new Vector3(2.3f, 0.55f, -2.73f);
                    //arms.transform.localRotation = Quaternion.Euler(-8.7f, 96.23f, -30.9f);
                }

                gettinArm = true;

         
                

                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (getPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(getPoint.position, getRange);
    }


}
