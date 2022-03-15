using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed;
    bool right=false, left=false, forward=false, back=false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game On!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("up")){
            forward = true;
        }
        if (Input.GetKey("a") || Input.GetKey("left")){
            left = true;
        }
        if (Input.GetKey("s") || Input.GetKey("down")){
            back = true;
        }
        if (Input.GetKey("d") || Input.GetKey("right")){
            right = true;
        }
    }

    void FixedUpdate(){
        if (forward){
            playerRb.AddForce(0, 0, speed * 10 * Time.deltaTime);
        }
        if (back){
            playerRb.AddForce(0, 0, -speed * 10 * Time.deltaTime);
        }
        if (left){
            playerRb.AddForce(-speed * 10 * Time.deltaTime, 0, 0);
        }
        if (right){
            playerRb.AddForce(speed * 10 * Time.deltaTime, 0, 0);
        }
        forward = back = left = right = false;
    }
}
