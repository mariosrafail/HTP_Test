using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGrounded : MonoBehaviour
{
    public playerWalking playerScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            playerScript.isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            //Invoke("setGroundedToFalse", 0.02f);
            playerScript.isGrounded = false;
        }
    }
    public void setGroundedToFalse()
    {
        playerScript.isGrounded = false;
    }
}
