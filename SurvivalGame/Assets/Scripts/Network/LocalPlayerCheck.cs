using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LocalPlayerCheck : NetworkBehaviour
{
    public GameObject Cam;
    public GameObject GroundCheck;
    public GameObject MeleeSP;
    public GameObject Model;
    public GameObject Name;

    void Start()
    {

        if (!IsLocalPlayer)
        {
            Cam.SetActive(false);
            MeleeSP.SetActive(false);
            GroundCheck.SetActive(false);
            ChangeLayerRecursively(Model, 0);
            ChangeLayerRecursively(Name, 0);
        }
    }
    void ChangeLayerRecursively(GameObject currentGameObject, int newLayer)
    {
        currentGameObject.layer = newLayer;

        foreach (Transform child in currentGameObject.transform)
        {
            ChangeLayerRecursively(child.gameObject, newLayer);
        }
    }
}

