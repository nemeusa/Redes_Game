using Fusion;
using UnityEngine;

public class SwitchObject : NetworkBehaviour
{
    GameObject obj;
    //[SerializeField] private GameObject chair;
    //[SerializeField] private GameObject maza;

    //[Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    //public void RpcToggleChildMaza()
    //{
    //    bool newState = !maza.activeSelf;
    //    maza.SetActive(newState);
    //}

    //[Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    //public void RpcToggleChildChair()
    //{
    //    bool newState = !chair.activeSelf;
    //    chair.SetActive(newState);
    //}


    //public void ToggleChildMaza()
    //{
    //    if (HasStateAuthority)
    //        RpcToggleChildMaza();
    //}

    //public void ToggleChildChair()
    //{
    //    if (HasStateAuthority)
    //        RpcToggleChildChair();
    //}

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
     public void RpcToggleChild()
    {
        bool newState = !obj.activeSelf;
        obj.SetActive(newState);
    }

    public void ToggleChild(GameObject ob)
    {
        obj = ob;
        if (HasStateAuthority)
            RpcToggleChild();
    }
}
