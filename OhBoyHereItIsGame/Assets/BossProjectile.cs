using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public playerMovement playMove;
    public Fire fire;
    public float lifetimeTime;
    
    private void Start()
    {
       
        playMove = FindObjectOfType<playerMovement>();
        damage = playMove.rangedDamage;
        lifetimeTime = lifeTime;
        fire = FindObjectOfType<Fire>();
    }

    private void Update()
    {
        if (lifetimeTime > 0)
        {
            lifetimeTime -= Time.deltaTime;
        }
        else
        {
            fire.fist.SetActive(true);
            Destroy(gameObject);
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().hurtPlayer(damage);
                soundManager.PlaySound("DamageTaken");
                fire.fist.SetActive(true);
            }
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void setDamage(int dmg)
    {
        damage = dmg;
    }
    
}
