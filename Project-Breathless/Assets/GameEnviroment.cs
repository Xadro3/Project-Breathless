using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnviroment : MonoBehaviour
{

    private static GameEnviroment instance = null;
    private List<GameObject> tiles = new List<GameObject>();
    private List<Tile> tile = new List<Tile>();
    private GameObject[,] twoTiles;
    public List<GameObject> Tiles
    {
        get { return tiles; }
    }
    public void SortTiles()
    {
        tile.Sort();
        foreach(Tile i in tile)
        {
            //Debug.Log(i.gameObject.transform.position.z + " " + i.gameObject.transform.position.x);
        }
    }
    public void convertTiles()
    {
        foreach( GameObject i in tiles)
        {
            tile.Add(i.GetComponent<Tile>());
        }
    }
    public void initArray()
    {
        twoTiles = new GameObject[(int)(tile[tile.Count-1].transform.position.z - tile[0].transform.position.z)+1, (int)(tile[tile.Count-1].transform.position.x - tile[0].transform.position.x)+1];
        float lastPos = tile[0].transform.position.z;

        for(int i=0; i<twoTiles.GetLength(0); i++)
        {
            for (int c = 0; c < twoTiles.GetLength(1); c++)
            {
                twoTiles[i, c] = tile[i * twoTiles.GetLength(1)+c].gameObject;
                //Debug.Log(twoTiles[i, c].transform.position);
                twoTiles[i, c].gameObject.GetComponentInChildren<TextMesh>().text = twoTiles[i, c].transform.position.ToString();
            }
        }
    }
    public static GameEnviroment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject(typeof(GameEnviroment).Name).AddComponent<GameEnviroment>();
                instance.Tiles.AddRange(GameObject.FindGameObjectsWithTag("Floor"));
                instance.convertTiles();
                instance.SortTiles();
                instance.initArray();
                Debug.Log(instance.twoTiles.Length);
                
            }
            return instance;
        }
    }
    

}
