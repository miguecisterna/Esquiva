using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Collider groundCheck;
    public float speed;
    private Vector2 move;
    public bool isColliding = false;
    public string checkCollide = "";
    public float jumpSpeed = 1;

    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Update()
    {
        movePlayer();
    }

    private void OnTriggerEnter(Collider other){        
        if (other.tag == "Ground"){
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other){        
        if (other.tag == "Ground"){
            isColliding = false;
        }
    }

    public void movePlayer(){
        Vector3 movement = new Vector3(move.x, 0f,move.y);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void jumpPlayer(){
        if (isColliding) {
            transform.position += Vector3.up * jumpSpeed;
        }
    }
}
