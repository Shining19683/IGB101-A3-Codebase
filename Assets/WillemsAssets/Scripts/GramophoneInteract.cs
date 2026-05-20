using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GramophoneInteract : MonoBehaviour
{
    // References
    GameManager gameManager;
    public GameObject player;
    public AudioSource levelMusic;
    public GameObject diskModel;

    // Variables
    public string nextLevel;
    private float distanceFrom;
    private bool finishingLevel = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        diskModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distanceFrom = Mathf.Sqrt(
            Mathf.Pow(transform.position.x-player.transform.position.x, 2.0f) +
            Mathf.Pow(transform.position.y-player.transform.position.y, 2.0f) +
            Mathf.Pow(transform.position.z-player.transform.position.z, 2.0f)
        );
        
        // Player interacts with gramophone when in proper range and proper level completion
        if (Input.GetKey("e") && distanceFrom < 2.5 && gameManager.levelComplete) {
            if (!finishingLevel) {
                levelMusic.Play();
                diskModel.SetActive(true);
                finishingLevel = true;
            } 
        } 
        if (finishingLevel && !levelMusic.isPlaying) {
            SceneManager.LoadScene(nextLevel);
        }
        
        // Potentially make the model look different with like shaders or something idk when in interaction range
        if (distanceFrom < 2.5) {

        }
        else {

        }
    }
}
