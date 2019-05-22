using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;

    SpacecraftData data;
    RollSpaceship rollChild;


    float MAX_SPEED;
    float MIN_SPEED;
    float speed;
    float yaw;
    float acceleration;

    public float turnMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
        PV = GetComponent<PhotonView>();
        rollChild = transform.GetChild(0).GetComponent<RollSpaceship>();
        data = GameObject.Find("SelectionManager").GetComponent<SpawnController>().Data;
        MAX_SPEED = data.MaximumSpeed;
        MIN_SPEED = data.MinimumSpeed;
        speed = MIN_SPEED;
        yaw = data.Yaw;
        acceleration = data.Acceleration;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("RoomController").GetComponent<PhotonRoom>().CurrentScene == 2)
        {
            transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
            transform.parent.position = new Vector3(0, 8, 0);
        }
        if (!PV.IsMine)
        {
            return;
        }
        //Set the turn multiplier
        turnMultiplier = Mathf.Clamp((MAX_SPEED / speed),0.8f,1.6f);
        //Get the input
        float x, y;
        float angle = transform.rotation.z;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //Accelerate
        if (y != 0)
        {
            if (y > 0)
            {
                speed += acceleration * Time.deltaTime;
                if(speed > MAX_SPEED)
                {
                    speed = MAX_SPEED;
                }
                //speed = Mathf.Lerp(speed, MAX_SPEED, Time.deltaTime * acceleration);
            }
            else if (y < 0)
            {
                speed -= acceleration * Time.deltaTime;
                if (speed < MAX_SPEED)
                {
                    speed = MIN_SPEED;
                }
                //speed = Mathf.Lerp(speed, MIN_SPEED, Time.deltaTime * acceleration * 0.5f);

            }
        }
        //Turn
        if (x != 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * Mathf.Sign(x) * yaw * turnMultiplier);
        }
        rollChild.Roll();
        transform.position += transform.forward * Time.deltaTime * speed;

    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float TurnMultiplier
    {
        get { return turnMultiplier; }
    }
    public SpacecraftData Data
    {
        get { return data; }
    }
}
