using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerTile;
    public GameObject player;
    public GameObject[,] tiles;
    int indexZ;
    int indexX;
    void Start()
    {
        tiles = GameEnviroment.Singleton.TwoTiles;
    }

    // Update is called once per frame
    void Update()
    {
        playerTile = player.GetComponent<PlayerController>().GetTile();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LocatePlayerTile();
            GridFloodFill(0, indexZ, indexX);
        }
        
    }

    void LocatePlayerTile()
    {
        indexZ = tiles.GetLength(0); //this is z 
        indexX = tiles.GetLength(1); // this is x

        for(int i = 0; i < indexZ; i++)
        {
            for(int y = 0; y < indexX; y++)
            {
                if(tiles[i, y].Equals(playerTile))
                {
                    indexX = y;
                    indexZ = i;
                    Debug.Log(indexX + " " + indexZ);
                    break;
                }
            }
        }

    }

    void GridFloodFill(int distance, int z, int x)
    {

        Debug.Log(distance);


        if (!tiles[z, x].GetComponent<Tile>().isObstacle && distance<=player.GetComponent<PlayerController>().range && !tiles[z, x].GetComponent<Tile>().visited)
        {
            tiles[z, x].GetComponent<Tile>().visited = true;
            tiles[z, x].GetComponent<Hoverable>().ColorMe();


          
            if (z + 1 < tiles.GetLength(0))
            {
                GridFloodFill(distance + 1, z + 1, x);
            }
            if (z - 1 > 0)
            {
                GridFloodFill(distance + 1, z - 1, x);
            }
            if (x + 1 < tiles.GetLength(1))
            {
                GridFloodFill(distance + 1, z, x + 1);
            }
            if (x - 1 > 0)
            {
                GridFloodFill(distance + 1, z, x - 1);
            }



        }
    }
}
