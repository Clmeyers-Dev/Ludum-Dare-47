using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Aim : MonoBehaviour
{
    // Start is called before the first frame update
    public float startTime;
    public float CurrentTime;
    public GameObject bullet;
    public float offset;
    public Transform firePoint;
    private Transform target;
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot()
    {

        Vector3 difference = target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Instantiate(bullet, firePoint.position, firePoint.rotation);

        CurrentTime -= Time.deltaTime;
    }
}
