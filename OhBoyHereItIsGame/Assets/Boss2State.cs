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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempTarget = FindObjectOfType<lineDrop>().transform.position;
        target = tempTarget;
        lineScript.MakeLine();
        if (CurrentTime <= startTime)
        {
            
            CurrentTime += Time.deltaTime;
        }
        else if(CurrentTime>= startTime)
        {
            Boss2Aim.shoot();
            while (transform.position.x != target.x)
            {
                move();

            }
            CurrentTime = 0;
        }
       

    }
    public void move()
    {
        float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, speed);
    }
}
