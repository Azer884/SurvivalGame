using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator anim;
    private MeleeSystem meleeSystem;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetLayerWeight(1,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            anim.SetLayerWeight(1,1f);
        }
        else{
            anim.SetLayerWeight(1,0f);
        }
    }
}
