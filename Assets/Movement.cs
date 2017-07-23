using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    GameObject ship;
    Rigidbody rb;

    public float turnspeed = 2f;
    public float speed = 10f;
    public float trueSpeed = 0.0f;

    // Use this for initialization
    void Start ()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        rb = ship.GetComponent<Rigidbody>();
        rb.useGravity = false;
	}

    // Update is called once per frame
    void Update()
    {
        var roll = Input.GetAxis("Roll");
        var pitch = Input.GetAxis("Pitch");
        var yaw = Input.GetAxis("Yaw");
        var power = Input.GetAxis("Power");

        //Truespeed controls
        trueSpeed += (power / 10);
        if (trueSpeed > 16)
        {
            trueSpeed = 16;
        }
        if (trueSpeed < -8)
        {
            trueSpeed = -8;
        }

        rb.AddRelativeTorque(pitch * turnspeed * Time.deltaTime, yaw * turnspeed * Time.deltaTime, roll * turnspeed * Time.deltaTime);
        rb.AddRelativeForce(0, 0, trueSpeed * speed * Time.deltaTime);
    }


}