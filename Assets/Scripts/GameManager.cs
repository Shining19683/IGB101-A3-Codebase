using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text pickupText;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;
    public float audioStopDistance = 6.0f;
    private bool[] isFading;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 6;
    public bool levelComplete = false;

    void Start()
    {
        isFading = new bool[audioSources.Length];
    }

    void Update()
    {
        LevelCompleteCheck();
        updateGUI();
        playAudioSamples();
    }

    private void updateGUI()
    {
        if (pickupText != null)
            pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    private void playAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            float distance = Vector3.Distance(player.transform.position, audioSources[i].transform.position);

            if (distance <= audioProximity)
            {
                isFading[i] = false;
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].volume = 1f;
                    audioSources[i].Play();
                }
            }
            else if (distance > audioStopDistance)
            {
                if (audioSources[i].isPlaying && !isFading[i])
                {
                    isFading[i] = true;
                    StartCoroutine(FadeOut(audioSources[i], 1.5f));
                }
            }
        }
    }

    private IEnumerator FadeOut(AudioSource source, float fadeDuration)
    {
        float startVolume = source.volume;
        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
        source.Stop();
        source.volume = startVolume;
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }
}