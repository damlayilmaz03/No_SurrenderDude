using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickcontroller : MonoBehaviour
{
    public Joystick joystick; // Joystick 
    public float moveSpeed = 6f; 

    private void Update()
    {
        
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // jostick i oynatınca player ı hareket ettirecek
        Vector3 movement = new Vector3(-horizontalInput, 0f,- verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
