using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreCounter : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    public static float scoreAmount;
    private float pointPerSecond;


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
        if(PlayerMovement.getPlayerStatus() == false){
            if(scoreText != null){
                scoreText.text = "Score: " + (int)scoreAmount;
                scoreAmount += pointPerSecond * Time.deltaTime;
            }
        }else{
            PlayerPrefs.SetFloat("yourscore", scoreAmount);
        }
    }
}