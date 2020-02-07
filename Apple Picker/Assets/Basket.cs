using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    [Header("set dynamically")]
    public Text scoreGT;

    private void Start()
    {
        //find score scounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }
    // Update is called once per frame
    void Update () {
        Vector3 mousePS2D = Input.mousePosition;
        mousePS2D.z = -Camera.main.transform.position.z;
        Vector3 mousePS3D = Camera.main.ScreenToWorldPoint(mousePS2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePS3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject colliedeWith = coll.gameObject;
        if (colliedeWith.tag == "Apple") {
            Destroy(colliedeWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
       
    }
}
