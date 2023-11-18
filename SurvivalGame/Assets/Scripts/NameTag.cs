using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    public string playerName;
    void Awake()
    {
        playerName = EditPlayerName.Instance.playerName;
    }

}
