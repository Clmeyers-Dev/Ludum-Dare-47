using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
  

    public float lifetimeTime;
    public GameObject sword;
    private void Start()
    {
        Invoke("LeaveProjectile", lifeTime);
       
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
            if (hitInfo.collider.CompareTag("Wall"))
            {
                LeaveProjectile();
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
        sword = Instantiate(sword, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
