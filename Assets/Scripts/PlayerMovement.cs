using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //unnecessary comment
    [SerializeField, Range(1,5)] private float speed = 1.5f;
    private float horizontal;
    private float vertical;
    private double maxFlyingTime = 1.0;
    private double flyingTime = 1.0;
    private bool canFly = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 1.0f), transform.position.z); // FIX THIS
        // Uncomment in order to debug
        // Debug.Log(flyingTime);
        getInput();
        
        Move();
    }

    private void getInput(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Space) && canFly == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*15, ForceMode.Force); // maybe there should be VelocityChange
            flyingTime -= Time.deltaTime;
            if(flyingTime < 0){
                canFly = false;
                flyingTime = 0;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0); // lose all forces in order to fall down
        }
        else if(flyingTime < maxFlyingTime)
        {
            if(flyingTime > 0.3)
                canFly = true;
            flyingTime += Time.deltaTime * 0.1; // can be done using Mathf.Clamp()
            if(flyingTime > maxFlyingTime)
                flyingTime = maxFlyingTime;
        }
    }

    private void Move(){
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);
        transform.Translate(changeInPosition * Time.deltaTime * speed);
    }
}
