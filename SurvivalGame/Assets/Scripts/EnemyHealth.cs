using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Transform cam;
    public GameObject HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() 
    {
        transform.LookAt(cam);    
    }
    // Update is called once per frame
}
