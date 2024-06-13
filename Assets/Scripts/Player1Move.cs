using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    private Animator anim;
    public float walkSpeed = 0.001f;
    private bool ýsJumping = false;
    private AnimatorStateInfo player1Layer0;
    private bool canWalkLeft = true;
    private bool canWalkRight = true;
    public GameObject player1;
    public GameObject opponent;
    private Vector3 oppPosition;
    private bool facingLeft = false;
    private bool facingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Listen to the Animator
        player1Layer0 = anim.GetCurrentAnimatorStateInfo(0);


        // Cannot exit screen
        Vector3 screenBounds = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenBounds.x > Screen.width - 200)
        {
            canWalkRight = false;
        }
        if (screenBounds.x < 200)
        {
            canWalkLeft = false;
        }
        else if (screenBounds.x > 200 && screenBounds.x < Screen.width - 200)
        {
            canWalkRight = true;
            canWalkLeft = true;
        }

        // Get the opponet's position
        oppPosition = opponent.transform.position;

        //Facing left or right of the Opponent
        if (oppPosition.x > player1.transform.position.x)
        {
            StartCoroutine(FaceLeft());
        }
        if (oppPosition.x < player1.transform.position.x)
        {
            StartCoroutine(FaceRight());
        }


        // Walking left and right
        if (player1Layer0.IsTag("Motion"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (canWalkRight)
                {
                    anim.SetBool("Forward", true);
                    transform.Translate(walkSpeed, 0, 0);
                }
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (canWalkLeft)
                {
                    anim.SetBool("Backward", true);
                    transform.Translate(-walkSpeed, 0, 0);
                }
            }
        }
        
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", false);
        }
        // Jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            if (ýsJumping == false)
            {
                ýsJumping = true;
                anim.SetTrigger("Jump");
                StartCoroutine(JumpPause());
            }
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

    IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(1.0f);
        ýsJumping = false;
    }

    IEnumerator FaceLeft()
    {
        if (facingLeft)
        {
            facingLeft = false;
            facingRight = true;
            yield return new WaitForSeconds(0.15f);
            player1.transform.Rotate(0, -180, 0);
        }
    }

    IEnumerator FaceRight()
    {
        if (facingRight)
        {
            facingLeft = true;
            facingRight = false;
            yield return new WaitForSeconds(0.15f);
            player1.transform.Rotate(0, 180, 0);
        }
    }
}
