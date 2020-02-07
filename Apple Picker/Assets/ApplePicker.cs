using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour {
    [Header("Set in Insepector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();
		for(int i =0; i < numBasket; i++)
        {
            GameObject tbasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tbasketGO.transform.position = pos;
            basketList.Add(tbasketGO);
        }
	}
	public void AppleDestroyed()
    {
        //destroy all of falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count  - 1;
        GameObject TBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(TBasketGO);
        if (basketIndex == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
        
    }
	// Update is called once per frame
	void Update () {
        
	}
}
