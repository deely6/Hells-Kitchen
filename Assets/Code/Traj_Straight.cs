using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Traj_Straight : MonoBehaviour,ITrajectory
{
    public float theta;
    public float speed;
    public bool active = false;
    public IWeapon weapon;
    int threeFrame= 0;
    public void OnActivate(Quaternion angle, Vector3 startPoint, float speed, IWeapon weapon)
    {
        theta = angle.eulerAngles.y * Mathf.Deg2Rad;
        active = true;
        this.weapon = weapon;
    }

    void Update()
    {
        if (active)
        {
            this.transform.position += new Vector3(-Mathf.Cos(theta), 0, Mathf.Sin(theta)) * speed *Time.deltaTime;
            if (!gameObject.GetComponent<Renderer>().isVisible && threeFrame>3) //offscreen
            {
                //Destroy(this.gameObject);
                weapon.OnDoDamage(new Damage(0), null, this.gameObject);
                active = false;
                threeFrame = 0;
            }
            threeFrame++;
        }
    }
}
