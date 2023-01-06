using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheckScr : MonoBehaviour
{
    public int boxNumber;
    public bool truckFilled;
    public int maxLimit;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boxNumber > maxLimit)
        {
            truckFilled = true;
        }
    }


    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Box") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            boxNumber++;  //set the pick up bool to true
            //ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }


}
