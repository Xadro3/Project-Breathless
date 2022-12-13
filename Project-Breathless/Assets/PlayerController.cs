using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{

    private NavMeshAgent nAgent;
    public GameObject tile;
    Ray ray;
    RaycastHit raycastHit;
    public int range;
    public bool isActive;
    void Start()
    {
       nAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isActive);
        if (Input.GetMouseButtonUp(2)&&isActive)
        {
            Debug.Log("i got here");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out raycastHit, 5000f,8);
            Debug.Log(raycastHit);
            nAgent.SetDestination(raycastHit.transform.position);
        }
       
    }
    public GameObject GetTile()
    {
        return tile;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Floor")
            {
                tile = other.gameObject;
                //Debug.Log(tile.transform.position);
            }
        
    }
    
}
