using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All HitBox should do is update weapon/collided with entity when GO collides with an entity

public class HitBox : MonoBehaviour
{

    public Damage damage;
    public IWeapon weapon;
    public IEntity user;
    bool active = false;


    public void OnBirth(IWeapon weapon, IEntity entity, Damage damage)
    {
        active = true;
        this.weapon = weapon;
        user = entity;
        this.damage = damage;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (active)
        {
            Debug.Log("collision" + this.name + " " + collision.gameObject.name + " " + user.getGameObject().name + " " +
                !((string.Equals(collision.gameObject.name, user.getGameObject().name)) ||
                (string.Equals(collision.gameObject.name, weapon.getGameObject().name))));
            IEntity col = collision.gameObject.GetComponent<IEntity>();
            if (col != null && !((string.Equals(collision.gameObject.name, user.getGameObject().name)) ||
                (string.Equals(collision.gameObject.name, weapon.getGameObject().name))))
            {
                Debug.Log(col.TakeDamage(damage).basicDamage);
                //user.OnDoDamage(damage);
                weapon.OnDoDamage(damage, col, this.gameObject);
                //Destroy(this.gameObject);
            }
        }
    }
}
