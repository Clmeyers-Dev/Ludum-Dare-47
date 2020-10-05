using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    EnemyHealthManager eHManager;
    public int playerDamage =1;
   
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void setPlayerDamage(int damage)
    {
        playerDamage = damage;
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
           eHManager = other.GetComponent<EnemyHealthManager>();
            eHManager.HurtEnemy(playerDamage);
            //Destroy(other.gameObject);
        }
    }
}
