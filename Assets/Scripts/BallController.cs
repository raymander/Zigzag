using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Use this for initialization
    void Start () {
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started){
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);


        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
            //making the ball fall
            //Debug.Log("game over");
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }
        if (!gameOver && Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            SwitchDirection();
        }
	}
             
    void SwitchDirection() {
        if(rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
