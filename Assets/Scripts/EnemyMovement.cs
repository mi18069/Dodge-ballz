using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Range(0.5f, 3.0f)] private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = new Vector3(Random.Range(-359, 359), 0.0f, Random.Range(-359, 359));
        Vector3 randomPosition = new Vector3(Random.Range(-6.0f, 6.0f), 0.35f, Random.Range(-6.0f, 6.0f));
        direction.Normalize();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction*speed*0.0000006f, ForceMode.Impulse);
       // uncomment this to get random position on the map
       // transform.position = randomPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(speed < 3.0f)
        speed += (float)Time.deltaTime*0.01f; // Enemies reaches maximum speed after 200 seconds
    }

    void OnCollisionExit(Collision other)
    {
        if(other.transform.tag != "Plane"){
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized*speed*2;
        }
    }

}
