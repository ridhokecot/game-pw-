using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keepAudio : MonoBehaviour
{
    private static keepAudio instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "gameplayTengananMap")
        {
            Destroy(gameObject);
        }
        if (currentScene.name == "gameplayBaliForestMap")
        {
            Destroy(gameObject);
        }
        if (currentScene.name == "gameplayKutaMap")
        {
            Destroy(gameObject);
        }
    }
}
