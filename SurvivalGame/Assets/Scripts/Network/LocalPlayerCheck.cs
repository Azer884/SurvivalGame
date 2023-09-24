using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LocalPlayerCheck : NetworkBehaviour
{
    public GameObject Cam;
    public GameObject GroundCheck;
    public GameObject MeleeSP;
    public GameObject Model;
    void Start()
    {

        if (!IsLocalPlayer)
        {
            Cam.SetActive(false);
            MeleeSP.SetActive(false);
            GroundCheck.SetActive(false);
        }
        else 
        {
            Model.SetActive(false);
        }
    }
}

