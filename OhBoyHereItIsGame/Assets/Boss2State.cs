using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2State : MonoBehaviour
{
    public float startTime;
    public float CurrentTime;
    public Vector2 target;
    public Vector2 tempTarget;
    public float speed = 10.0f;
    public LineScript lineScript;
    public Boss2Aim Boss2Aim;
    public EnemyHealthManager eHealthMan;
    public playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        tempTarget = FindObjectOfType<lineDrop>().transform.position;
        if(tempTarget!=null)
            target = new Vector3(tempTarget.x, tempTarget.y, tempTarget.y);

        lineScript.MakeLine();
        if (CurrentTime <= startTime)
        {
            
            CurrentTime += Time.deltaTime;
        }
        else if(CurrentTime>= startTime)
        {
            Boss2Aim.shoot();
            target = target = new Vector3(tempTarget.x, tempTarget.y, tempTarget.y);
            /* while (transform.position.x != target.x)
             {
                // transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                 if(transform.position.x == target.x)
                 {
                     break;
                 }
             }*/
            CurrentTime = 0;

            
        }
        if (eHealthMan.currentHealth <= 0)
        {
            //display somthing
            player.setCanDash(true);
            Destroy(gameObject);
        }

    }
    public void move()
    {
        float step = speed * Time.deltaTime;
        
    }
}
