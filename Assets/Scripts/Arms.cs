using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Arms : NetworkBehaviour
{
    public bool inHand;
    public Transform getPoint;
    public Transform playerGetPoint;
    public WeaponsType weaponsType;

    //private void Update()
    //{
    //    if (inHand)
    //    {
    //        if (GetComponent<Renderer>() != null)
    //        GetComponent<Renderer>().material.color = Color.white;
    //        else GetComponentInChildren<Renderer>().material.color = Color.white;

    //        //getPoint.localPosition = playerGetPoint.localPosition;
    //    }
}

public enum WeaponsType
{
   Masa,
   Chair
}
