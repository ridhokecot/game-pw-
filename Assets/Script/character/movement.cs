using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    Vector3 move;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        transform.position += move * speed * Time.deltaTime;

        if (move != Vector3.zero)
        {
            animator.SetBool("Move", true);//
        }
        else
        {
            animator.SetBool("Move", false); //
        }


        if (move == Vector3.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (move == Vector3.left)
        {
            transform.rotation = Quaternion.Euler(0, 200, 0);
        }
    }
}
