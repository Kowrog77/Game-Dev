using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCamera : MonoBehaviour {
    //static var
    static private int w, h;
    static private int[,] MAP;
    static public Sprite[] SPRITES;
    static public Transform TILE_ANCHOR;
    static public Tile[,] TILES;
    [Header("Set in Inspector")]
    public TextAsset mapData;
    public Texture2D mapTiles;
    public TextAsset mapCollisions;
    public Tile tilePrefab;

	// Use this for initialization
	void Awake () {
        LoadMap();

	}
    public void LoadMap()
    {
        GameObject go = new GameObject("TILE_ANCHOR");
        TILE_ANCHOR = go.transform;

        SPRITES = Resources.LoadAll<Sprite>(mapTiles.name);
        string[] lines = mapData.text.Split('\n');
        h = lines.Length;
        string[] tileNums = lines[0].Split(' ');
        w = tileNums.Length;
        System.Globalization.NumberStyles hexNum;
        hexNum = System.Globalization.NumberStyles.HexNumber;


        MAP = new int[w, h];
        for(int j=0; j<h; j++)
        {
            tileNums = lines[j].Split(' ');
            for(int i=0; i < w; i++)
            {
                if (tileNums[i] == "..") MAP[i, j] = 0;
                else MAP[i,j] = int.Parse(tileNums[i], hexNum);
            }//end of row for loop
        }//end of column for loop
        print("Parsed" + SPRITES.Length + "sprites");
        print("Map size:"+w+"wide by"+h+"high");
        ShowMap();
    }
    void ShowMap()
    {
        TILES = new Tile[w, h];
        for ( int j = 0;j < h; j++){
            for(int i = 0; i < w; i++)
            {
                if (MAP[i, j] != 0)
                {
                    Tile ti = Instantiate<Tile>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR);
                    ti.SetTile(i, j);
                    TILES[i, j] = ti;
                }
            }
        }
    }
    static public int GET_MAP(int x, int y)
    {
        if(x<0|| x>=w|| y < 0 || y >= h)
        {
            return -1;
        }
        return MAP[x, y];
    }//end of get MAP method
    static public int GET_MAP(float x, float y)
    {
        int tX = Mathf.RoundToInt(x);
        int tY = Mathf.RoundToInt(y - 0.25f);
        return GET_MAP(tX, tY);
    }//end of get MAP method
  
	// Update is called once per frame
	static public void SET_MAP(int x,int y,int tNum) {
		if(x<0 || x>= w|| y < 0 || y >= h)
        {
            return;
        }
        MAP[x, y] = tNum;
	}//end of set map
}
