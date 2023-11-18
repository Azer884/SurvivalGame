using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LocalPlayerCheck : NetworkBehaviour
{
    public GameObject Cam;
    public GameObject GroundCheck;
    public GameObject MeleeSP;
    public GameObject Model;
    public GameObject Short;
    public GameObject Shirt;
    public GameObject Bones;
    public GameObject Name;

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
            Name.SetActive(false);
            Model.SetActive(false);
            Short.SetActive(false);
            Shirt.SetActive(false);
            Bones.SetActive(false);
        }
    }
}

