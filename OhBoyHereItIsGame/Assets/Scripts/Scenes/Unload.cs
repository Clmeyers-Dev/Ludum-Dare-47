using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Unload : MonoBehaviour
{
    public int scene;
    bool unloaded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("unload");
        if (!unloaded)
        {
            unloaded = true;
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
