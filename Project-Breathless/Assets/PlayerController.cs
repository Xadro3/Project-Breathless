using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{

    private NavMeshAgent nAgent;
    GameObject tile;
    Ray ray;
    RaycastHit raycastHit;
    public int range;
    void Start()
    {
       nAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(2))
        {
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
        Debug.Log(other);

        if (other.gameObject.tag == "Floor")
            {
                tile = other.gameObject;
                Debug.Log(tile.transform.position);
            }
        
    }
    
}
