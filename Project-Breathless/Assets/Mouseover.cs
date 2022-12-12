using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouseover : MonoBehaviour
{
    // Start is called before the first frame update
    public RaycastHit raycastHit;
    Ray hoverRay;
    Collider lastObject = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hoverRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(hoverRay, out raycastHit, 5000f,8);



        if(raycastHit.collider != lastObject)
        {
            //Debug.Log(raycastHit.collider.gameObject);

            
            if(lastObject != null)
            {
                lastObject.gameObject.GetComponent<Hoverable>().DecolorMe();

            }



            lastObject = raycastHit.collider;

            if (lastObject != null)
            {
                lastObject.gameObject.GetComponent<Hoverable>().ColorMe();
            }
        }
        else if (raycastHit.collider == null)
        {
            if(lastObject != null)
            {
                lastObject.gameObject.GetComponent<Hoverable>().DecolorMe();
               
            }


        }
       
       
    }


}
