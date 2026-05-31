using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSwitch1 : MonoBehaviour
{
    GameManager1 gameManager;
    public string nextLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
    }
    private void OnTriggerEnter(Collider otherObject)

    {
        if (otherObject.transform.tag == "Player")
        {
            if (gameManager.levelComplete)
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
