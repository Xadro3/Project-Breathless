using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerTile;
    public GameObject player;
    GameObject[,] tiles;
    void Start()
    {
        tiles = GameEnviroment.Singleton.TwoTiles;
    }

    // Update is called once per frame
    void Update()
    {
        playerTile = player.GetComponent<PlayerController>().GetTile();
        
    }

    void GridRangeColorizer()
    {
        int indexZ = tiles.GetLength(0);
        int indexX = tiles.GetLength(1);

        for(int i = 0; i < indexZ; i++)
        {
            for(int y = 0; y < indexX; y++)
            {
                if(tiles[i, y].Equals(playerTile))
                {
                    indexX = y;
                    indexZ = i;
                    break;
                }
            }
        }



     
    }
}
