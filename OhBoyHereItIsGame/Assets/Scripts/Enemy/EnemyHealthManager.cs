using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int MaxHealth;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer EnemySprite;
    public GameObject deathDust;
    void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
   
    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
        if (currentHealth <= 0)
        {
            // sound();
            Instantiate(deathDust, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

