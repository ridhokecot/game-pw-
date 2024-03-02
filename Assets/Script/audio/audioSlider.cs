using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioSlider : MonoBehaviour
{
    [SerializeField] Slider SoundVolume;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = SoundVolume.value;
        Save();
    }

    private void Load()
    {
        SoundVolume.value = PlayerPrefs.GetFloat("SoundVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume.value);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
