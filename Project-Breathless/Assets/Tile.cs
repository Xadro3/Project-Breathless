using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IComparable<Tile>
{

    public int distance;
    public bool visited;
    public bool isObstacle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int CompareTo(Tile that)
    {
        if (this.transform.position.z < that.transform.position.z) return -1;
        if (this.transform.position.z == that.transform.position.z)
        {
            if(this.transform.position.x < that.transform.position.x)
            {
                return -1;
            }
            if(this.transform.position.x > that.transform.position.x)
            {
                return 1;
            }
        }
        return 1;
    }
}
