using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerTile;
    public GameObject player;
    List<GameObject> tiles;
    void Start()
    {
        tiles = GameEnviroment.Singleton.Tiles;
    }

    // Update is called once per frame
    void Update()
    {
        playerTile = player.GetComponent<PlayerController>().GetTile();
    }

    void GridRangeColorizer()
    {

    }
}
