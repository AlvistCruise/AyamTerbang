using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider ground){
        if(ground.CompareTag("Ground")){
            transform.parent.GetComponent<PlayerJump>().isGrounded=true;
            transform.parent.GetComponent<PlayerJump>().currentTotalJump=0;
        }
    }
}
