using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RollSpaceship : MonoBehaviour
{
    PhotonView PV;
    Rigidbody rigidbody;
    float roll;
    Quaternion limitRotation;
    float horizontal;
    float turnMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody>();
        limitRotation = Quaternion.Euler(0,0,0);
        roll = transform.parent.GetComponent<PlayerMovement>().Data.Roll;
        horizontal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        //Receive turn multiplier from parent
        turnMultiplier = transform.parent.GetComponent<PlayerMovement>().TurnMultiplier;
        //Store the input in the  horizontal axis
        horizontal = Input.GetAxis("Horizontal");
        //set rotation limits depending on input
        SetRotateLimit(horizontal, turnMultiplier);
        //Rotate ship
    }

    //Set rotation limit
    void SetRotateLimit(float axis, float multiplier)
    {
        if(axis == 0)
        {
            limitRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (axis > 0)
        {
            limitRotation = Quaternion.Euler(0, 0, -45 * multiplier);
        }
        else
        {
            limitRotation = Quaternion.Euler(0, 0, 45 * multiplier);
        }
    }

    //Roll to side
    public void Roll()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, limitRotation, Time.deltaTime * roll * turnMultiplier);
    }
}
