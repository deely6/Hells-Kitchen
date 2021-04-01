using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour, IEntity
{
    Damage health = new Damage(10);
    public GameObject getGameObject()
    {
        return this.gameObject;
    }

    public void OnBirth()
    {
        throw new System.NotImplementedException();
    }

    public void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public void OnDoDamage(Damage Damage)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnterRoom()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(IEntity Entity)
    {
        throw new System.NotImplementedException();
    }

    public void OnLeaveRoom()
    {
        throw new System.NotImplementedException();
    }

    public void OnWeaponFire()
    {
        throw new System.NotImplementedException();
    }

    public Damage TakeDamage(Damage damage)
    {
        health.basicDamage -= damage.basicDamage;
        if (health.basicDamage == 0)
        {
            Destroy(this.gameObject);
        }
        return health;
    }
}
