using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public string nametag;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(nametag).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {  
        transform.position = target.position;
    }
}
