using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public playerMovement playMove;
   
    public float lifetimeTime;
   public GameObject sword;
    private void Start()
    {
        Invoke("LeaveProjectile", lifeTime);
        playMove = FindObjectOfType<playerMovement>();
        damage = playMove.rangedDamage;
        lifetimeTime = lifeTime;
    }

    private void Update()
    {
        if (lifetimeTime > 0)
        {
            lifetimeTime -= Time.deltaTime;
        }
        else
        {
            LeaveProjectile();
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
            }
            LeaveProjectile();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void setDamage(int dmg)
    {
        damage = dmg;
    }
    void LeaveProjectile()
    {
      sword= Instantiate(sword, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
