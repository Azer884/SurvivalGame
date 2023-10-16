using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
	[SerializeField] private GameObject Cam;


    private void Awake() {

	    hostBtn.onClick.AddListener(() => {
		    NetworkManager.Singleton.StartHost();
			Destroy(Cam);
	    });

	    clientBtn.onClick.AddListener(() => {
		    NetworkManager.Singleton.StartClient();
			Destroy(Cam);
	    });
    }

}
