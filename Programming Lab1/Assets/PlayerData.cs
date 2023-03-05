using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    public int ReturnHealth()
    {
        return (int)Enum.PLAYER_HEALTH;
    }
}
