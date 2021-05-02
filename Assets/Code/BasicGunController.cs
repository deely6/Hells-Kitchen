using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunController : MonoBehaviour,IWeapon
{
    public GameObject bullet;
    public IEntity holder;
    List<GameObject> bullets=new List<GameObject>();
    public int bulletIterator;
    public float fireRate = .1f;
    float fireDelayCount = 0;

    [System.Serializable]
    class BulletTrajectory
    {
        public GameObject bullet;
        public float theta;
        public float speed = .4f;
        public bool active=false;
        public BulletTrajectory(GameObject b, float t)
        {
            bullet = b; theta = t;
            active = false;
        }
        public Vector3 getDeltaPosition()
        {
            return (new Vector3(-Mathf.Cos(theta), 0, Mathf.Sin(theta))*speed);
        }
    }

    public void Activate(IEntity entity)
    {
        throw new System.NotImplementedException();
    }

    public GameObject getGameObject()
    {
        return this.gameObject;
    }

    public void OnDoDamage(Damage damage,IEntity damagedEntity,GameObject bull)
    {
        bull.transform.position = new Vector3(100, 100, 100);
    }

    public void OnDrop()
    {}

    public void OnFire()
    {
        Debug.Log("fire"+ fireDelayCount);
        //bullets.Add(Instantiate(bullet, this.transform.position, transform.rotation));//new BulletTrajectory(Instantiate(bullet,this.transform.position,transform.rotation), transform.eulerAngles.y * Mathf.Deg2Rad));
        if (fireDelayCount <= 0)
        {
            bullets[bulletIterator].transform.position = this.transform.position;
            bullets[bulletIterator].transform.rotation = this.transform.rotation;
            ((HitBox)bullets[bulletIterator].GetComponent(typeof(HitBox))).OnBirth(this, holder, new Damage(1));
            ((ITrajectory)bullets[bulletIterator].GetComponent(typeof(ITrajectory))).OnActivate(this.transform.rotation, this.transform.position, 1000, this);
            Debug.Log(bullets[bulletIterator].transform.position + " " + bullets[bulletIterator].name);
            bulletIterator++;
            Debug.Log(bulletIterator + " " + bullets.Count);
            if (bulletIterator == bullets.Count) { bulletIterator = 0; }
            fireDelayCount = fireRate;
        }
    }

    public void OnPickup(IEntity entity)
    {
        holder = entity;
    }

    public void OnSwap()
    {}

    public void Update()
    {
        if (fireDelayCount > 0) { fireDelayCount-=Time.deltaTime; }
    }

    public void Start()
    {
        for(int i = 0; i < 30; ++i)
        {
            bullets.Add(Instantiate(bullet, new Vector3(100,100,100), transform.rotation));
            bullets[bullets.Count - 1].name = "bullet#" + i;
        }
        bulletIterator = 0;
    }

    public void OnHoldFire()
    {
        throw new System.NotImplementedException();
    }

    public void OnReleaseFire()
    {
        throw new System.NotImplementedException();
    }
}
