using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerCameraManager : NetworkBehaviour
{
    public GameObject cameraPrefab;
    private GameObject playerCamera;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        // Spawn a camera for this player
        if (IsOwner)
        {
            playerCamera = Instantiate(cameraPrefab);
            playerCamera.GetComponent<Camera>().enabled = true;
        }
    }
}
