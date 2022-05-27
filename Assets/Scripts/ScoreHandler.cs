using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yourScore;
    private float yourScoreVal;

    // Start is called before the first frame update
    void Start()
    {
        yourScore = GetComponent<TextMeshProUGUI> ();
        yourScoreVal = PlayerPrefs.GetFloat("yourscore");
        yourScore.text = "" + (int)yourScoreVal;
        
    }

}
