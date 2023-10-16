using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public bool PlayerRange;  
 
    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRange = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRange = false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerRange && SelectionManager.Instance.onTarget)
        {
            
        }
    }
}