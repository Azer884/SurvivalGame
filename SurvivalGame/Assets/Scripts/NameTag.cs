using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    void Awake()
    {
        playerName.text = EditPlayerName.Instance.playerName;
    }

}
