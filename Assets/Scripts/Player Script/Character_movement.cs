using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    private CharacterController characterController;
   
   
    public bool isGrounded = false;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>(); 
        characterController = GetComponent<CharacterController>();
       

    }

    private void Update()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        float vertical_move = Input.GetAxis("Vertical");
        float scale = transform.localScale.z;

        Vector3 move = new Vector3(-horizontal_move, 0f, -vertical_move);
        transform.Translate(move*speed*Time.deltaTime);

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {

            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
