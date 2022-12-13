using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players;
    GameObject activePlayer;
    int nextPlayer;
    void Start()
    {
        
        players[0].GetComponent<PlayerController>().isActive = true;
        activePlayer = players[0];
        nextPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            activePlayer.GetComponent<PlayerController>().isActive = false;

            if (nextPlayer + 1 >= players.Length)
            {
                
                nextPlayer = -1;
            }
            Debug.Log(activePlayer.name);
            activePlayer = players[nextPlayer + 1];
            nextPlayer++;
            activePlayer.GetComponent<PlayerController>().isActive = true;

        }
    }
}
