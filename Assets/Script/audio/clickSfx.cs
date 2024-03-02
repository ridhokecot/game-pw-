using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSfx : MonoBehaviour
{
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playClick()
    {
        click.Play();
    }
}
