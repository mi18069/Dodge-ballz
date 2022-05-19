using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField, Range(1,5)] private float speed = 2.0f;
    private float horizontal;
    private float vertical;
    public double maxFlyingTime = 1.0;
    public double flyingTime = 1.0;
    private bool canFly = true;
    private bool canBeFilled = true;
    private bool isDestroyed = false;
    private bool flying = false;
    private Rigidbody rb;

    public UIFlyingBar fBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame

    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 1.1f), transform.position.z); // FIX THIS
        if(transform.position.y <= 0.36f)
        {
            flying = false;
            canBeFilled = true;
        }
        else
        {
            canBeFilled = false;
        }

        getInput();

        fBar.updateFlyingBar();

        if(!isDestroyed)
        {
            Move();
        }
    }

    private void getInput(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(flying)
        {
            rb.AddForce(Vector3.down, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.Space) && canFly == true)
        {
            flying = false;
            rb.AddForce(Vector3.up*3, ForceMode.VelocityChange); // maybe there should be VelocityChange
            flyingTime -= Time.deltaTime;
            if(flyingTime <= 0){
                canFly = false;
                flying = true;
                flyingTime = 0;
                rb.velocity = new Vector3(0,0,0); // lose all forces in order to fall down
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector3(0,0,0); // lose all forces in order to fall down
            flying = true;
        }
        else if(flyingTime < maxFlyingTime)
        {
            if(flyingTime > 0.3)
            {
                canFly = true;
            }
            if(canBeFilled)
                flyingTime += Time.deltaTime * 0.1; // can be done using Mathf.Clamp()
            if(flyingTime > maxFlyingTime)
                flyingTime = maxFlyingTime;
        }
    }

    private void Move()
    {
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);

        //changeInPosition = changeInPosition.normalized * speed * Time.deltaTime;
        //rb.MovePosition(transform.position + changeInPosition); // Not working with flying, inertia  
        
        rb.velocity = changeInPosition * speed; // Gravity not working properly

        //rb.AddForce(changeInPosition.normalized*speed*0.1f, ForceMode.VelocityChange); // Accumulating too much force 
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.transform.tag == "Enemy"){
            isDestroyed = true;
            rb.velocity = Vector3.zero;
        }
        
    }
}