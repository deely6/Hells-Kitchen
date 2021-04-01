using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCameraTransition : MonoBehaviour
{
    public bool active = false;
    public float speed;
    public Vector3 nextPostition;
    public Vector3 positionChange;

    public void OnTriggerEnter(Collider collision)
    {
        Vector3 collisionRelative = this.transform.InverseTransformPoint(collision.transform.position);
        Debug.Log(collisionRelative+this.name);
        if (collisionRelative.y<0) {
            active = true;
            positionChange = (nextPostition - Camera.main.transform.position) / speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Camera.main.transform.position += positionChange;
            if (Vector3.Distance(Camera.main.transform.position,nextPostition)<1) { active = false; }
        }
    }
}
