using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;      // for pausing and restarting the game

public class GameBehaviour : MonoBehaviour
{
    // backing variables
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // public variables
    [SerializeField] private int MaxItems = 4;
    [SerializeField] private Text HealthText;
    [SerializeField] private Text ItemText;
    [SerializeField] private Text ProgressText;
    [SerializeField] private Button WinButton;

    void Start()
    {
        ItemText.text = "Items Collected: " + _itemsCollected;   // string concatenation 
        HealthText.text = "Player Health: " + _playerHP;      
    }

    // gets and sets
    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            ItemText.text = "ItemsCollected: " + _itemsCollected;
            if(_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);       // display the winning message

                Time.timeScale = 0f;        // pause the game
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more to go!";
            }

            /*Debug.LogFormat("Items: {0}", _itemsCollected);*/    
        }
    }

    public int HP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;

            HealthText.text = "Player Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    
    public void RestartScene()
    {
        SceneManager.LoadScene(0);      // load scene from the beginning -- ika restart

        Time.timeScale = 1f;
    }
}
