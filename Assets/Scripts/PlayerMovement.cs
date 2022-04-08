using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField, Range(1,5)] private float speed = 0.5f;
    private float horizontal;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        
        Move();
    }

    private void getInput(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move(){
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);
        transform.Translate(changeInPosition * Time.deltaTime * speed);
    }
}
