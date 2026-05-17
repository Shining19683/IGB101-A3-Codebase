using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameManager_miq gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<GameManager_miq>();
        
    }
    private void OnTriggerEnter(Collider otherObject){
        if(otherObject.transform.tag == "Player"){gameManager.CurrentPickups += 1;
        Destroy(this.gameObject);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
