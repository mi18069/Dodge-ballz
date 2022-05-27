using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGate : MonoBehaviour
{
    private float secondsToLift = 3.0f;
     public float liftingTimer = 0.0f;
     public float openingTimer = 0.0f;
     public float waitingTimer = 0.0f;
     public Vector3 Point;
     public Vector3 Difference;
     public Vector3 start;
     public float percent ;
     public bool isClosed = true;
     public bool roundFinished = false;

     public float waitingToClose = 2.0f+3.0f+2.0f;
     public float waitingToOpen = 2.0f;
     



    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        Point = start + new Vector3(0.0f, 1.0f, 0.0f);

        Difference = Point - start;


    }

    // Update is called once per frame
    void Update()
    {
        if(isClosed)
        {
            if(openingTimer > waitingToOpen)
            {
                openGate();
            } 
            openingTimer += Time.deltaTime;

        }else
        {
            if(waitingTimer > waitingToClose)
            {
                closeGate();
            }
            waitingTimer += Time.deltaTime;

        }
        
        if(roundFinished == true)
        {
            openingTimer = 0.0f;
            waitingTimer = 0.0f;
            roundFinished = false;
        }


    }

    void openGate()
    {
        if(liftingTimer <= secondsToLift)
        {
            liftingTimer += Time.deltaTime;
            percent = liftingTimer / secondsToLift;

            transform.position = start + Difference * percent;
        }else
        {
            liftingTimer = 0.0f;
            isClosed = false;
        }

    }

    void closeGate()
    {
        if(liftingTimer <= secondsToLift)
        {
            liftingTimer += Time.deltaTime;
            percent = liftingTimer / secondsToLift;

            transform.position = Point-Difference * percent;
        }else
        {
            liftingTimer = 0.0f;
            isClosed = true;
            roundFinished = true;
        }
    }
}
