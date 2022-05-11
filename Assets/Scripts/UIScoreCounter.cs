using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreCounter : MonoBehaviour
{

    public Text scoreText;
    public static float scoreAmount;
    public float pointPerSecond;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text> ();
        scoreAmount = 0f;
        pointPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + (int)scoreAmount;
        scoreAmount += pointPerSecond * Time.deltaTime;
    }
}
