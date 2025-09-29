using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class GetWeapons : NetworkBehaviour
{
    [Header("Ajustes de ataque")]
    public float getRange = 1.5f;      
    public float getRate = 1f;         
    public LayerMask objectLayer;          // Qué capas detecta como objeto

    [Header("Referencias")]
    public Transform getPoint;        
    public Animator animator;
    public Arms currentArms;

    private WeaponsType weaponsType;

    bool gettinArm;

    public void Update()
    {
        // Input de agarre
        if (Input.GetKeyDown(KeyCode.E) && !gettinArm)
        {
            GetObjects2();
        }
        //if (currentArms != null) currentArms.transform.position = getPoint.position;
    }

    void GetObjects2()
    {
        Collider[] getArms = Physics.OverlapSphere(getPoint.position, getRange, objectLayer);

        foreach (Collider arms in getArms)
        {
            currentArms = arms.GetComponent<Arms>();
            if (currentArms != null)
            {
                currentArms.inHand = true;

                // Lo pegamos a la mano
                arms.transform.SetParent(getPoint);
                if (currentArms.weaponsType == WeaponsType.Masa)
                {
                    arms.transform.localPosition = new Vector3(1.32f, 12.15f, 0.85f);
                    arms.transform.localRotation = Quaternion.Euler(262, 0, 0);
                }

                else
                {
                    arms.transform.localPosition = new Vector3(0.0518481f, 0.1003463f, 0.4738743f);
                    arms.transform.localRotation = Quaternion.Euler(-138.785f, -3.242981f, 90);
                }

                // Desactivar físicas para que no caiga
                Rigidbody rb = arms.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.isKinematic = true;
                    Debug.Log("getting");
                }

                gettinArm = true;

                break; // Agarramos solo uno
            }
            //if (arms != null)
            //{
            //    currentArms = arms.GetComponent<Arms>();
            //    var actuallyArms = arms.GetComponent<Arms>();
            //    actuallyArms.inHand = true;

            //    // --- Nuevo ---
            //    // Queremos que el getPoint del arma coincida con el getPoint del jugador
            //    Transform weaponRoot = actuallyArms.transform;

            //    // Guardamos la posición y rotación para que el getPoint del arma quede
            //    // exactamente en el mismo lugar/rotación que el getPoint del jugador
            //    weaponRoot.SetParent(transform);
            //    Vector3 offset = weaponRoot.position - actuallyArms.getPoint.position;
            //    Quaternion rotOffset = Quaternion.Inverse(actuallyArms.getPoint.localRotation);

            //    // Ajustar posición y rotación para alinear ambos puntos
            //    weaponRoot.position = getPoint.position + offset;
            //    weaponRoot.rotation = getPoint.rotation * rotOffset;

            //    Rigidbody rb = weaponRoot.GetComponent<Rigidbody>();
            //    if (rb) rb.isKinematic = true;

            //    break;
            //}
        }
    }

    // Para visualizar el rango en la escena
    private void OnDrawGizmosSelected()
    {
        if (getPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(getPoint.position, getRange);
    }
}
