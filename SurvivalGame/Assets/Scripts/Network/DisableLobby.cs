using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class DisableLobby : NetworkBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (IsServer)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
