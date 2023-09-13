using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCam : MonoBehaviour
{
    public Transform Player;
    public float Sensitivity = 100f; 
    private float Xrotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Xlook = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime ;
        float Ylook = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime ;
        
        Xrotate -= Ylook;
        Xrotate = Mathf.Clamp(Xrotate ,-90f ,90f);

        Player.Rotate(Vector3.up * Xlook);
        transform.localRotation = Quaternion.Euler(Xrotate, 0f, 0f);
    }
}
