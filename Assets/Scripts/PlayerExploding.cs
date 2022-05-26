using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExploding : MonoBehaviour
{

    public GameObject objectToActivateAndDeactivate;
    [SerializeField] private ParticleSystem playerExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.transform.tag == "Enemy"){
            playerExplosion.Play();  
            StartCoroutine(GameOverCoroutine());

            objectToActivateAndDeactivate.SetActive(false);
        }
        
    }

    public IEnumerator GameOverCoroutine(){
        yield return new WaitForSecondsRealtime(2f);
        
        
        SceneManager.LoadScene("GameOver");
    }
}
