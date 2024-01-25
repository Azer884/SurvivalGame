using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InventorySystem : MonoBehaviour
{
 
   public static InventorySystem Instance { get; set; }
 
    public GameObject inventoryScreenUI;
    public GameObject inventoryHotBarUI;
    public bool isOpen;
 
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    void Start()
    {
        isOpen = false;
    }
 
 
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
 
			Debug.Log("Tab is pressed");
            inventoryScreenUI.SetActive(true);
            inventoryHotBarUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            inventoryHotBarUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false;
        }
    }
 
}