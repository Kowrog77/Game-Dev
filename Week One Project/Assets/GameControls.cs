using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour {
    public GameObject ballPrefab;
    public GameObject ball;
    public Rigidbody rb;
    public float speed =0;
    public float speedMulti = 1;
    public float Shoot;

    // Use this for initialization
    void Start () {
        ball = Instantiate<GameObject>(ballPrefab);
         rb = ball.GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void Update () {
         Shoot = Input.GetAxis("Shoot");
        if(rb.velocity.magnitude== 0)
        {
            if (Shoot != 0)
            {
                speed += speedMulti;
            }
            else if (speed != 0)
            {

                rb.AddForce(transform.right * speed, ForceMode.Impulse);

                speed = 0;
            }
        }
        
        
    
}
    
}
