using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Insepector")]
    public GameObject applePrefab;
    //speed at which the apple tree moves
    public float speed = 5f;
    //distance where the Apple Treee turns around 
    public float leftAndRightEdge = 20f;
    //chance tree changes direction
    public float chanceToChangeDirections = 0.01f;
    //rate at which apple with be instantitated
    public float secondsBetweenAppleDrops = 1f;
    // Use this for initialization
    void Start () {
        //setting up to drop apples every second
        Invoke("DropApple", 2f);
	}
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);        apple.transform.position = transform.position;        Invoke("DropApple", secondsBetweenAppleDrops);

    }

    // Update is called once per frame
    void Update () {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //changing directions 
        if (pos.x < -leftAndRightEdge) speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge) speed = -Mathf.Abs(speed);
        
	}
    private void FixedUpdate()
    {
       if (Random.value < chanceToChangeDirections) speed *= -1;
    }
}
