using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float jumpForce;
    public bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded=false;

        }
        
    }
}
