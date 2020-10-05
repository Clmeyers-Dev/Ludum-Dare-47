using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{

    public float offset;
    public playerMovement playMove;
    public Animator PlayerAnimator;
    public GameObject projectile;
    // public GameObject shotEffect;
    public Transform shotPoint;

    private float timeBtwShots;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public float startTimeBtwShots;


    private void Start()
    {

    }
    private void Update()
    {

        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(1)&&playMove.hasSword&&playMove.canRanged)
            {
             
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                playMove.setHasSword(false);
            }
            else
            {
               
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }
}
