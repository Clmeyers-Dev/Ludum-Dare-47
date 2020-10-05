using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip BossOneSound, BossTwoSound, DamageTaken, Laser_Shoot, SwordHit, SwordPickup, SwordShoot, BossDamageTaken;
    static AudioSource audiosrc;
    void Start()
    {
        DamageTaken = Resources.Load<AudioClip>("DamageTaken");
        BossOneSound = Resources.Load<AudioClip>("BossOneSound");
        BossTwoSound = Resources.Load<AudioClip>("BossTwoSound");
        Laser_Shoot = Resources.Load<AudioClip>("Laser_Shoot");
        SwordHit = Resources.Load<AudioClip>("SwordHit");
        SwordPickup = Resources.Load<AudioClip>("SwordPickup");
        SwordShoot = Resources.Load<AudioClip>("SwordShoot");
        BossDamageTaken = Resources.Load<AudioClip>("BossDamageTaken");

        audiosrc = GetComponent<AudioSource>();
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "DamageTaken":
                audiosrc.PlayOneShot(DamageTaken);
                break;
            case "BossOneSound":
                audiosrc.PlayOneShot(BossOneSound);
                break;
            case "BossTwoSound":
                audiosrc.PlayOneShot(BossTwoSound);
                break;
            case "Laser_Shoot":
                audiosrc.PlayOneShot(Laser_Shoot);
                break;
            case "SwordHit":
                audiosrc.PlayOneShot(SwordHit);
                break;
            case "SwordShoot":
                audiosrc.PlayOneShot(SwordShoot);
                break;
            case "SwordPickup":
                audiosrc.PlayOneShot(SwordPickup);
                break;
            case "BossDamageTaken":
                audiosrc.PlayOneShot(BossDamageTaken);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
