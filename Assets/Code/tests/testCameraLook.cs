using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCameraLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane testPlane = new Plane(Vector3.up, new Vector3(0, this.transform.position.y, 0));
        //this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+ new Vector3(-6, -6, -6);
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
        float enter;
        if(testPlane.Raycast(ray,out enter))
        {
            Vector3 difference = ray.GetPoint(enter) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotation_z, 0f);
        }
        else
        {
            Debug.Log("no connection");
        }
        ray = Camera.main.ScreenPointToRay(new Vector3(50, 50, 0));
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
    }
}
