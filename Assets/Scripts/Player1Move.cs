using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    private Animator anim;
    public float walkSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking left and right
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Forward", true);
            transform.Translate(walkSpeed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Backward", true);
            transform.Translate(-walkSpeed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", false);
        }
        // Jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetTrigger("Jump");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("Crouch", true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            anim.SetBool("Crouch", false);
        }
    }
}
