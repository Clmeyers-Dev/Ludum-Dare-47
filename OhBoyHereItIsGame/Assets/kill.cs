using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyHealthManager eHealthMan;
    public playerMovement player;
    void Start()
    {
        player = FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eHealthMan.currentHealth <= 0)
        {
            //display somthing
            player.setCanDash(true);
            Destroy(gameObject);
        }
    }
}
