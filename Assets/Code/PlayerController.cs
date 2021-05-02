using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    public float speed = 100;
    public GameObject gun;
    public CharacterController characterController;

    bool collided = false;

    public void OnDeath(){} //what happens when entity dies
    public void OnBirth(){
        ((IWeapon)gun.GetComponent(typeof(IWeapon))).OnPickup(this);
    }
    public void OnLeaveRoom(){}
    public void OnEnterRoom(){}
    public void OnWeaponFire(){
        ((IWeapon)gun.GetComponent(typeof(IWeapon))).OnFire();
    }
    public void OnDoDamage(Damage Damage)
    {
        throw new System.NotImplementedException();
    }

    Damage IEntity.TakeDamage(Damage damage)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(IEntity Entity)
    {
        throw new System.NotImplementedException();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnBirth();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            OnWeaponFire();
        }

        //look where mouse is pointing
        Plane testPlane = new Plane(Vector3.up, new Vector3(0, this.transform.position.y, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter;
        if (testPlane.Raycast(ray, out enter))
        {
            Vector3 difference = ray.GetPoint(enter) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotation_z, 0f);
            //this.transform.rotation=Quaternion.LookRotation(ray.GetPoint(enter),Vector3.up);
        }
    }
    void LateUpdate()
    {
        if (!collided) { move(); }
    }

    void move()
    {
        Camera m_Camera = Camera.main;
        float theta = m_Camera.transform.eulerAngles.y*Mathf.Deg2Rad;
        Vector3 move = new Vector3();

        move += new Vector3(Mathf.Sin(theta), 0, Mathf.Cos(theta))*speed* Input.GetAxis("Vertical") * Time.deltaTime;
        move += m_Camera.transform.right * speed* Input.GetAxis("Horizontal")* Time.deltaTime;
        move += new Vector3(0, -9.8f* Time.deltaTime, 0);
        characterController.Move(move);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionRelative = this.transform.InverseTransformPoint(collision.transform.position);
        Debug.Log(collisionRelative + this.name);
        if (collisionRelative.y > 0)
        {
            //collided = true;
        }
    }

    public GameObject getGameObject()
    {
        return this.gameObject;
    }
}
