using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public GameBehaviour GameManager;
    
    private void Start()
    {
        GameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
        Debug.Log("I am a health bar");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item Collected!");

            GameManager.Items += 1;
        }
    }
}
