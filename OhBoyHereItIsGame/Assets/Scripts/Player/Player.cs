using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject player;
    public bool canBeHurt;
    public float currentHealth;
    public float maxHealth;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
   public SceneManage sceny;
    private SpriteRenderer playerSprite;
    public bool gameStart;
    public GameObject origin;
 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
        if(currentHealth <= 0)
        {
           
            Debug.Log("kill player and bring to first level");
           
            Reset();
            //kill player and send back to first scene 
        }

        

    }
    public void Reset()
    {
        gameStart = false;
        currentHealth = maxHealth;


        transform.position = origin.transform.position;

        for (int i = 0; i <= SceneManager.sceneCount-1; i++)
        {
            if (i == 0)
            {

            }
            else
            {
                Debug.Log("unload scene " + i);
                SceneManager.UnloadSceneAsync(i);
            }
           
        }
        if (!gameStart)
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;
        }
        
    }
    public void hurtPlayer(int damage)
    {
        currentHealth -= damage;
        flashActive = true;
        flashCounter = flashLength;


    }
}

