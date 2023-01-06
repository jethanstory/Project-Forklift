using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheckScr : MonoBehaviour
{
    public int boxNumber;
    public bool truckFilled;
    public int maxLimit;
    public GameObject truckFilledCanvas;
    public float secondsCount;
    

    // Start is called before the first frame update
    void Start()
    {
        truckFilledCanvas.SetActive(false);
        secondsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxNumber > maxLimit)
        {
            truckFilled = true;
            secondsCount += Time.deltaTime;

            if (secondsCount < 5)
            {
                truckFilledCanvas.SetActive(true);
            }
            else
            {
                truckFilledCanvas.SetActive(false);
                secondsCount = 10;
            }
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

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Box") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            boxNumber--;
        }
    }


}
