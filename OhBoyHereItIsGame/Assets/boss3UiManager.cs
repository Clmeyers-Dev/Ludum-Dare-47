using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class boss3UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyHealthManager enemyHealth;
    public Slider healthBar;
    void Start()
    {
        //enemyHealth = FindObjectOfType<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = enemyHealth.MaxHealth;
        healthBar.value = enemyHealth.currentHealth;
    }
}
