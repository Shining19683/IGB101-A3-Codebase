using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public TextMeshProUGUI pickupText;

    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    void Start()
    {

    }
    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }




    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }
    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
    }
}
