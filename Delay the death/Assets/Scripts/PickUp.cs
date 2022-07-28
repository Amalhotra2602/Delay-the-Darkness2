using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject heldObj;
    public float pickUpRange;
    public Transform holdParent;
    public float moveForce = 250;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {

            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                DropObj();

            }

                

        }

        if (heldObj != null)
        {
            MoveObj();

        }
    }

    void MoveObj()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.transform.position) < 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            


            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObj()
    {
        
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
       heldRig.useGravity = true;
       

        heldObj.transform.parent = null;
        heldObj = null;

    }
}


