using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform firePoint;
    private Transform target;
    public float offset;
    public float playerDistance;
    public bool PlayerInRange;
    [SerializeField]
    private float maxRange = 10;
    [SerializeField]
    private float minRange = 1;
    public float startTime;
    public float CurrentTime;
    public float playerAway;
    public float playerPosition;
    public float meleeRange;
    public Animator anim;

    public GameObject fist;
    void Start()
    {
        PlayerInRange = false;
        target = FindObjectOfType<Player>().transform;
    }
    public void shoot()
    {
        if (CurrentTime >= startTime)
        {
            Vector3 difference = target.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            anim.SetBool("hasFist", true);
            fist.SetActive(false);
            CurrentTime -= Time.deltaTime;
        }
        else if (CurrentTime < startTime)
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0)
            {
                
                CurrentTime = startTime;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        /* Vector3 difference = target.position - transform.position;
         float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
         shoot();*/

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {


            PlayerInRange = true;
        }
        else
        {
            PlayerInRange = false;
        }
        playerDistance = Vector3.Distance(target.position, transform.position);
        if (PlayerInRange)
        {
            //AttackRanged
            shoot();
        }
    }

}

