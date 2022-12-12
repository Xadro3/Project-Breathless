using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer render;
    private Color originalColor;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        originalColor = render.material.color;
    }

    public void ColorMe()
    {

        render.material.color = Color.red;
    }
    public void ColoroMeBlue()
    {
        render.material.color = Color.blue;
    }
    public void DecolorMe()
    {
        render.material.color = originalColor;
    }
    
}
