using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour
{
    float forceThrow = 900;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    public bool trailerTrigger = false;



    void Update()
    {
         distance = Vector3.Distance (item.transform.position, tempParent.transform.position);
        if (distance >= 1f) 
        {
            isHolding = false;
        }
        //Check if isholding
        if (isHolding == true) {

        item.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        item.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
        item.transform.SetParent (tempParent.transform);

            if (Input.GetMouseButtonDown (1)) {
                item.GetComponent<Rigidbody> ().AddForce (tempParent.transform.forward * forceThrow);
                isHolding = false;
            }
        }
        else 
        {
            objectPos = item.transform.position;
            item.transform.SetParent (null);
            item.GetComponent<Rigidbody> ().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown() 
    {
    
    // if (!trailerTrigger)
    // {
        if (distance <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody> ().useGravity = false;
            item.GetComponent<Rigidbody> ().detectCollisions = true;
        }
    // }
    }
    void OnMouseUp() 
    {
        isHolding = false;
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "BoxCheck") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            if (isHolding)
            {
                trailerTrigger = true;
            }

        }
    }
        
}
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
//}

