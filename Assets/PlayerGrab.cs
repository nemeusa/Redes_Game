using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [Header("Configuraci�n de agarre")]
    public Transform holdPoint;          // Punto donde se agarra el objeto
    public float grabRange = 2f;         // Distancia m�xima para agarrar
    public KeyCode grabKey = KeyCode.E;  // Tecla para agarrar/soltar

    private GameObject heldObject;       // Objeto actualmente agarrado
    private Rigidbody heldRb;

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (heldObject == null)
            {
                TryGrab();
            }
            else
            {
                Drop();
            }
        }
    }

    void TryGrab()
    {
        // Detectar objetos cerca con un Raycast
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, grabRange))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                // Desactivar f�sicas mientras est� agarrado
                heldRb.isKinematic = true;

                // Posicionarlo en la mano
                heldObject.transform.SetParent(holdPoint);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void Drop()
    {
        if (heldObject != null)
        {
            // Soltar
            heldObject.transform.SetParent(null);
            heldRb.isKinematic = false;

            // Opci�n: darle un peque�o empuj�n hacia adelante
            heldRb.AddForce(transform.forward * 5f, ForceMode.Impulse);

            heldObject = null;
            heldRb = null;
        }
    }
}
