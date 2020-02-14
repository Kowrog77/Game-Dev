using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    public GameObject ballPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Hole")
        {
            GameObject ball = Instantiate<GameObject>(ballPrefab);
            Destroy(this.gameObject);
        }
    }
}
