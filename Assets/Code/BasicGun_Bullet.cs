using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun_Bullet : MonoBehaviour,IHitBox
{
    Damage damage = new Damage(1);
    float speed=.4f;
    float theta= 0;
    Vector3 axis = Vector3.zero;
    bool active = false;
    IWeapon weapon;
    IEntity user;

    public void OnBirth(IWeapon weapon, IEntity entity)
    {
        active = true;
        this.weapon = weapon;
        user = entity;
        //transform.rotation.ToAngleAxis(out theta,out axis);
        //Debug.Log(axis+" "+theta);
        theta = transform.eulerAngles.y * Mathf.Deg2Rad;
        Debug.Log(axis + " " + theta);
    }

    public void OnHit()
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(Damage damage, IEntity entity)
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (active)
        {
            transform.position += new Vector3(-Mathf.Cos(theta),0,Mathf.Sin(theta)) * speed;
            if (!this.gameObject.GetComponent<Renderer>().isVisible)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log("collision"+this.name+" "+collision.gameObject.name+ " "+ user.getGameObject().name + " "+ 
            !((string.Equals(collision.gameObject.name, user.getGameObject().name)) ||
            (string.Equals(collision.gameObject.name, weapon.getGameObject().name))));
        IEntity col = collision.gameObject.GetComponent<IEntity>();
        if (col!=null && !((string.Equals(collision.gameObject.name,user.getGameObject().name)) ||
            (string.Equals(collision.gameObject.name, weapon.getGameObject().name))))
        {
            Debug.Log(col.TakeDamage(damage).basicDamage);
            //weapon.OnDoDamage(damage);
            user.OnDoDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
