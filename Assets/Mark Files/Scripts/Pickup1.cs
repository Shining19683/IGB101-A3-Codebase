using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager1 gameManager;





    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
    }

    private void OnTriggerEnter(Collider otherObject)

    {
        if (otherObject.tag == "Player")
        {
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
        }
    
    
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
