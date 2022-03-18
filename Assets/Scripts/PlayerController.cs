using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed;
    bool right=false, left=false, forward=false, back=false;
    private int score = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game On!");
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0){
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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

    void OnTriggerEnter(Collider other){
        if (other.tag == "Pickup"){
            score++;
            Debug.Log($"Score: {score}");
        }
        if (other.tag == "Trap"){
            health--;
            Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal"){
            Debug.Log("You win!");
        }
    }
}
