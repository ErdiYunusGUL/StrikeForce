using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{

    public float jumpSpeed = 1.0f;
    public GameObject player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpUp()
    {
        player1.transform.Translate(0, jumpSpeed, 0);
    }
}
