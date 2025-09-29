using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PickUpController : MonoBehaviour
{
    public Weapon weaponScript;
    public Rigidbody rb;
    public BoxCollider collider;
    public Transform player, weaponContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;




    
    // Start is called before the first frame update
    private void Start()
    {
        if (!equipped)
        {
            weaponScript.enabled = false;
            rb.isKinematic = false;
            collider.isTrigger = false;
        }
        else
        {
            weaponScript.enabled = true;
            rb.isKinematic = true;
            collider.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    private void UpdateNetwork()
    {
        //checking distance to player
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) Pickup();

        if (equipped && Input.GetKeyDown(KeyCode.E)) Drop();
    }

    private void Pickup()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        collider.isTrigger = true;

        weaponScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        collider.isTrigger = false;

        //carry player momentum
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(player.forward * dropUpwardForce, ForceMode.Impulse);
        //random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        weaponScript.enabled = false;
    }
}
