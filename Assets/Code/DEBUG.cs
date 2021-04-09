using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (Event.current!= null)
        {
            GUI.Label(new Rect(10, 10, 100, 20), Input.GetAxis("Vertical") +" VERT");
            GUI.Label(new Rect(10, 30, 100, 20), Input.GetAxis("Horizontal") + " HORZ");
        }
    }
}
