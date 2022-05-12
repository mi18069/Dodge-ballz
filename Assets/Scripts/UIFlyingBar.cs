
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFlyingBar : MonoBehaviour
{
    
    [SerializeField] private Image flyingBarImage;

    public PlayerMovement player;

    public void updateFlyingBar()
    {
        flyingBarImage.fillAmount = Mathf.Clamp((float)player.flyingTime / (float)player.maxFlyingTime, 0, 1f);
    }
}