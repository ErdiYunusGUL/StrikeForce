using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{

    public float jumpSpeed = 1.0f;
    public GameObject player1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("LightPunch");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("HeavyPunch");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetTrigger("LightKick");
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("HeavyKick");
        }
    }

    public void JumpUp()
    {
        player1.transform.Translate(0, jumpSpeed, 0);
    }

    public void FlipUp()
    {
        player1.transform.Translate(0, jumpSpeed, 0);
        player1.transform.Translate(0.1f, 0, 0);
    }

    public void FlipBack()
    {
        player1.transform.Translate(0, jumpSpeed, 0);
        player1.transform.Translate(-0.1f, 0, 0);
    }
}
