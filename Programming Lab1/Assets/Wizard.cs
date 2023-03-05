using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    
    Enemy myEnemy = new Enemy();


    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "sword" && myEnemy.enemyHealth <= 0)
            Debug.Log("You Killed the Wizard!!!!");
    }
}
