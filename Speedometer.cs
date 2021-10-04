using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{

    private const float max_speed_angle = -103;
    private const float zero_speed_angle = 103;
    private Transform needletransform;

    private float speedmax;
    private float speed;
    private void Awake()
    {
        needletransform = transform.Find("needle");

        speed = 0f;
        speedmax = 200f;
    }
    
 

    // Update is called once per frame
    private void Update()
    {
        HandlePlayerInput();
       // speed += 30f * Time.deltaTime;
       // if (speed > speedmax) speed = speedmax;

        needletransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
     
        
    }
    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float acceleration = 50f;
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            float deceleration = 20f;
            speed -= deceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float brakespeed = 100f;
            speed -= brakespeed * Time.deltaTime;
        }
        speed = Mathf.Clamp(speed, 0f, speedmax);

    }

    private float GetSpeedRotation()
    {
        float totalanglesize = zero_speed_angle - max_speed_angle;
        float speedNormalized = speed / speedmax;
        return  zero_speed_angle - speedNormalized * totalanglesize;
    }
}
