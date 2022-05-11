
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingBar : MonoBehaviour
{
    
    [SerializeField] private Image flyingBarImage;

    public PlayerMovement player;

    //ne radi lepo

    // public GameObject player;

    // var fTime = player.GetComponent("flyingTime");
    // var maxFTime = player.GetComponent("maxFlyingTime");
    public void updateFlyingBar()
    {
        flyingBarImage.fillAmount = Mathf.Clamp((float)player.flyingTime / (float)player.maxFlyingTime, 0, 1f);
    }
}