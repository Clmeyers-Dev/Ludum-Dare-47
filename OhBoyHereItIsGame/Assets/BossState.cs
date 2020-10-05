using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    // Start is called before the first frame update
    public DefaultEnemy defaultEnemy;
    public EnemyHealthManager eHealthMan;
    public playerMovement playMove;
    public ShakeBehavior shakebake;
    public float SlamTime;
    public float SlamStartTime;
    public Fire fire;
    void Start()
    {
        shakebake = FindObjectOfType<ShakeBehavior>();
        playMove = FindObjectOfType<playerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Slam();
        if (eHealthMan.currentHealth <= 0)
        {
            playMove.setCanRanged(true);
            Destroy(gameObject);
        }
    }
    public void fistShot()
    {
        fire.shoot();
    }
    public void Slam()
    {
        if (defaultEnemy.melee != true)
        {
            SlamTime = 0;
            defaultEnemy.animator.SetBool("Slam", false);
        }
        else
        {
            SlamTime += Time.deltaTime;
        }
        if (SlamTime>=SlamStartTime)
        {
            Debug.Log("should slam");
            defaultEnemy.animator.SetBool("Slam", true);
            shakebake.TriggerShake();
            SlamTime = 0;
        }
        else
        {
            defaultEnemy.animator.SetBool("Slam", false);
            
        }
    }
}
