using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class homeManager : MonoBehaviour
{
    public GameObject prefabs;
    public GameObject creditPrefabs;

    public void prefabOnTrigger()
    {
        prefabs.SetActive(true);
    }

    public void prefabsOffTrigger()
    {
        prefabs.SetActive(false);
    }

    public void creditOnTrigger()
    {
        creditPrefabs.SetActive(true);
    }

    public void creditOffTrigger()
    {
        creditPrefabs.SetActive(false);
    }

    void Start()
    {
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            prefabsOffTrigger();
            creditOffTrigger();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
