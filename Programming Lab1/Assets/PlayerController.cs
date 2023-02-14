using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public int playerHP;

    private void Start()
    {
        playerHP = PlayerData.Instance.ReturnHealth();
        Debug.Log($"Player HP is {playerHP}");
    }

}
