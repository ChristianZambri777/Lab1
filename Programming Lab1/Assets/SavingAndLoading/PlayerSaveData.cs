using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    public int health;
    public int deaths;
    public Vector3 position;
    

    public PlayerSaveData()
    {
        health = 10;
        deaths = 0;
        position = Vector3.zero;
    }
}
