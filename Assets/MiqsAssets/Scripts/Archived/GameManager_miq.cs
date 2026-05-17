using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager_miq: MonoBehaviour{
    public GameObject Player;

//Pickup and Level Completion Logic
    public int MaxPickups = 5;
    public int CurrentPickups = 0;
    public bool LevelComplete = false;
    public TextMeshPro pickupText;
    

//Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;
    public float audioStopDistance = 6.0f; 

private void LevelCompleteCheck(){
    if (CurrentPickups>=MaxPickups)
        LevelComplete = true;
    else
        LevelComplete = false;
}
private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + CurrentPickups + "/" + MaxPickups;
    }
//Loop for playing audio proximity events - Audio source based
private void playAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            float distance = Vector3.Distance(Player.transform.position, audioSources[i].transform.position);
        Debug.Log("Audio source " + i + " distance: " + distance + " proximity: " + audioProximity);
        
        if(distance <= audioProximity)
        {
            Debug.Log("In range! isPlaying: " + audioSources[i].isPlaying);
            if(!audioSources[i].isPlaying)
            {
                audioSources[i].Play();
            }
        
                else if(distance > audioStopDistance)
        {
                if(audioSources[i].isPlaying)
                {
                 audioSources[i].Stop();
                }
        }
            }
        }
    }
void Update(){

    LevelCompleteCheck();
    UpdateGUI();
    playAudioSamples();
}




}