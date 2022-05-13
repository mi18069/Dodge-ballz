using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField, Range(1,5)] private float speed = 1.5f;
    private float horizontal;
    private float vertical;
    public double maxFlyingTime = 1.0;
    public double flyingTime = 1.0;
    private bool canFly = true;
    private bool canBeFilled = true;
    private bool isDestroyed = false;

    public UIFlyingBar fBar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 1.1f), transform.position.z); // FIX THIS
        if(transform.position.y <= 0.36f)
        {
            canBeFilled = true;
        }
        else
        {
            canBeFilled = false;
        }
        // Uncomment in order to debug
        // Debug.Log(flyingTime);
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
        if(Input.GetKey(KeyCode.Space) && canFly == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*15, ForceMode.Force); // maybe there should be VelocityChange
            flyingTime -= Time.deltaTime;
            if(flyingTime <= 0){
                canFly = false;
                flyingTime = 0;
                GetComponent<Rigidbody>().velocity = new Vector3(0,0,0); // lose all forces in order to fall down
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0); // lose all forces in order to fall down
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

    private void Move(){
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);
        transform.Translate(changeInPosition * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.transform.tag == "Enemy"){
            isDestroyed = true;
        }
        
    }
}