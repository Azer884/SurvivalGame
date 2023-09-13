using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    public float VelocityX = 0f;
    public float VelocityZ = 0f;
    public float Acceleration = 2f;
    public float Decceleration = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool Forward = Input.GetKey("w");
        bool Backward = Input.GetKey("s");
        bool Rightward = Input.GetKey("d");
        bool Leftward = Input.GetKey("a");
        bool Shift = Input.GetKey("left shift");


        if (Forward && VelocityZ < 0.5f && !Shift)
        {
            VelocityZ += Time.deltaTime * Acceleration ;
        }
        if (Rightward && VelocityX < 0.5f)
        {
            VelocityX += Time.deltaTime * Acceleration ;
        }


        if (Backward && VelocityZ > -0.5f)
        {
            VelocityZ -= Time.deltaTime * Acceleration ;
        }
        if (Leftward && VelocityX > -0.5f)
        {
            VelocityX -= Time.deltaTime * Acceleration ;
        }
        
        
        //DECCELARATION

        if (!Forward && VelocityZ > 0f)
        {
            VelocityZ -= Time.deltaTime * Decceleration ;
        }
        if (!Rightward && VelocityX > 0f)
        {
            VelocityX -= Time.deltaTime * Decceleration ;
        }

        if (!Leftward && VelocityX < 0f)
        {
            VelocityX += Time.deltaTime * Decceleration ;
        }
        if (!Backward && VelocityZ < 0f)
        {
            VelocityZ += Time.deltaTime * Decceleration ;
        }
        

         if (Forward && VelocityZ < 1f && Shift)
        {
            VelocityZ += Time.deltaTime * Acceleration ;
        }
        if (Forward && VelocityZ > 0.5f && !Shift)
        {
            VelocityZ -= Time.deltaTime * Decceleration ;
        }

        animator.SetFloat("Velocity X", VelocityX);
        animator.SetFloat("Velocity Z", VelocityZ);
    }
    
}

