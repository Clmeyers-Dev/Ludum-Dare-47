using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    public static SceneManage sceneManage;
    bool gamestart;
    private void Awake()
    {
        if (!gamestart)
        {
            sceneManage = this;
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            gamestart = true;
        }
    }
    public void UnloadScene(int Scene)
    {
        StartCoroutine(Unload(Scene));
    }
    IEnumerator Unload(int scene)
    {
        yield return null;
        sceneManage.UnloadScene(scene);
    }
}
