using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Main : MonoBehaviour
{
    bool isActive;
    bool isPlayer;
    float hitPoints;
    float movementSpeed;
    int alertState;
    //map of weapons used by entity, map weapon game object? to weapons name
    //list of states
    //public map of specific entity classes, map Entity_Specfic cass to an enum saying when the specific class should run
    //public list of AI classes
    //list of targets for use by the AI class
    //public list of sounds
    //public list of animations, should this be here or somewhere else?
    //public Entity_DamageCalculations class for this entity

    //Create Events Here:
    //  Need event for taking damage, entering and leaving a room (if it is the player character), dying?, killing?, activation


    // Start is called before the first frame update
    void Start()
    {
        //add AI classes connected to the entities game object to the list of AI classes, the 'active' AI class is the one currently in use
        //add specific entity classes from the game object to the specific entity class map
        //setup listener for all events (i.e. take damage event and global state change event)
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //go through and call active AI class, any specific classes on this entity and then loop through state effects
        }
    }
    
    void FireWeapon()//weapon index, weapon name,fire or alt fire)
    {
        //why is this here again? The only thing that can fire a weapon would be the AI so why is this here again?
        //May need to put this in the AI class, but then the AI class will need to keep track of weapons. Not a huge deal.
        //Also will need to make sure every AI class has a 'fire weapon' method, it's an interface so also not a problem.
    }

    void ChangeAI()//New AI Class)
    {
        //deactivate current AI activate new AI class
    }

    void DoDamage()
    {
        //Calls damage calculations class and subtracts damage from HP
        //broadcasts that entity took damage and how much damage it took
        //loops through any 'onDamage' specific entity classes
    }

    void BroadCast(<T> paramaters,string name)
    {
        //broadcasts paramaters and name to all other entities?
    }

    void Listen(<T> paramaters,string name)
    {
        //listens for any broadcasts sent by other entities
    }

    void Destroy()
    {
        //delete this entity and unsubscribe to any events it currently is subscribed to to help with garbage collection
    }

    void Activate()
    {
        //activate this entity subscribe to all events
    }
}
