using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGate : MonoBehaviour
{
    private float seconds = 3f;
     public float timer = 0.0f;
     public Vector3 Point;
     public Vector3 Difference;
     public Vector3 start;
     public float percent ;



    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        // Debug.Log(start);
        Point = start + new Vector3(0.0f, 1.0f, 0.0f);
        // Debug.Log(Point);

        Difference = Point - start;


    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer <= seconds)
        {
            timer += Time.deltaTime;
            percent = timer / seconds;

            transform.position = start + Difference * percent;
            // Debug.Log("kraj " + transform.position + "    start " + start);
        }






    }
}
