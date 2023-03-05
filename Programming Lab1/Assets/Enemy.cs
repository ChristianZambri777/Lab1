using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

   // [SerializeField] private string enemyName;
    [SerializeField] private float speed;
    private float hp;
    [SerializeField] private float maxHP;

    [SerializeField] private Transform player;

   public int enemyHealth = (int)Enum.ENEMY_HEALTH;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyHealth <=0)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "sword")
        {
            enemyHealth--;
           
        }




    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enemyHealth--;
    }

    public int returnEnemyHP()
    {
        return enemyHealth;
    }
    


}
