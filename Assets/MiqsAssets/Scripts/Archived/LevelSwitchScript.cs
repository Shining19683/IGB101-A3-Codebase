using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchScript : MonoBehaviour
{
    GameManager_miq gameManager;
    public string nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      gameManager = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<GameManager_miq>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.transform.tag == "Player")
    {
        if(gameManager.LevelComplete)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
