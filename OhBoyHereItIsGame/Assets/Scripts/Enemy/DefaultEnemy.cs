using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    public Animator animator;
    private Transform target;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float maxRange = 10;
    [SerializeField]
    private float minRange = 1;
    public bool canBeKnockedBack;
    public float knockBack;
    public bool hasHome;
    public playerMovement playMove;
    public float lastMove;
    public EnemyHealthManager eHealthMan;
    [SerializeField]
    private bool regularFollow;
    // Use this for initialization
    void Start()
    {
        playMove = FindObjectOfType<playerMovement>();
        target = FindObjectOfType<playerMovement>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange && regularFollow)
        {
            FollowPlayer();
        }
        


    }
    public void FollowPlayer()
    {

        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", (target.position.x - transform.position.x));
        animator.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon" && canBeKnockedBack == true)
        {
            knockBack = (knockBack * lastMove);
            eHealthMan.HurtEnemy(2);
            transform.position = new Vector2(transform.position.x + knockBack, transform.position.y + 0);
        }
    }
}

