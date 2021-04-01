using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Utitly scripts, put all public interfaces and widely used classes/stucts here

public interface IEntity //interface used by player, enemies, npcs and anything that needs to take damage or is interactable
{
    GameObject getGameObject();
    void OnDeath(); //what happens when entity dies
    void OnBirth();
    void OnLeaveRoom();
    void OnEnterRoom();
    Damage TakeDamage(Damage damage); //do damage calculations based on original damage return damage delt
    void OnWeaponFire();
    void OnDoDamage(Damage Damage); //what happens when your character does damage, also includes killing
    void OnInteract(IEntity Entity); //what happens when your character interacts with another entity/entities interact with each other
}

public interface ITrajectory
{
    void OnActivate(Quaternion angle, Vector3 startPoint, float speed,IWeapon weapon);
}

public interface IWeapon //interface used by weapons
{
    GameObject getGameObject();
    void OnFire();
    void OnHoldFire();
    void OnReleaseFire();

    void OnPickup(IEntity entity);
    void OnDrop();
    void OnDoDamage(Damage damage,IEntity damagedEntity, GameObject hitBox); //what to do when hitbox needs to be destroyed, note this will also be called when bullet is off screen
    void OnSwap(); //use to handle weapon activation/deactivation
}

public interface IHitBox
{
    void OnHit(Damage damage,IEntity entity); //On hit return damage done and entity back to the hitbox
    void OnBirth(IWeapon weapon,IEntity entity); //hitboxes should be defined on a case by case basis
}

public class Damage //damage class will allow more flexability for how damage is dealt/allow for damage types
                    //should also be used for health bars to make things consistant?
{
    public int basicDamage;

    public float percentDamage; //used when returning damage done afer calculations, percent damage vs. original health of entity
    public bool didDamageKill; //used when returning damage done afer calculations, true if entity was killed

    public Damage(int dam)
    {
        basicDamage = dam;
    }
}