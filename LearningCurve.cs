using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public string firstName = "Peter";
    public int currentAge = 30;
    public int addedAge = 1;
    public int currentGold = 32;

    public bool PureOfHeart = true;
    public bool HasSecretIncantation = false;
    public string RareIterm = "Relic Stone";

    // Dictionary
    public Dictionary<string, int> ItermInventory = new Dictionary<string, int>()
    {
        {"Potion", 5 },
        {"Antidote", 7 },
        {"Aspirin", 1 }
    };
    

    // Start is called before the first frame update
    void Start()
    {
        int characterLevel = 19;

        string playerName = "Pike";

        HeroTrail(GenerateCharacter(playerName, characterLevel));

        Thievery();

        OpenTreasureChamber();

        Character hero = new Character();       // initialize self-created class: Character

        Debug.LogFormat("Hero: {0} - {1} EXP", hero.name, hero.exp);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// That's a method doc:
    /// </summary>
    void ComputeAge()
    {
        Debug.Log("Here's the debugging process: ");
        Debug.Log(currentAge + addedAge);
        Debug.LogFormat("Text goes here, add {0} and {1} as variable placeholders",
            currentAge, firstName);     // index matched with the variables followed
    }

    /// <summary>
    /// Generate a character with specified parameters
    /// </summary>
    public int GenerateCharacter(string name, int charLevel)
    {
        //Debug.LogFormat("Character info: {0} -- Level {1}", name, charLevel);
        return charLevel += 5;
    }

    /// <summary>
    /// This method takes in an input and log it on the console
    /// </summary>
    /// <param name="input"></param>
    public void HeroTrail(int input)
    {
        Debug.Log("Log input: " + input);
    }

    /// <summary>
    /// A method to test out the if-else statement
    /// </summary>
    public void Thievery()
    {
        if (currentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        } 
        else if (currentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("looks like your purse is in the sweet spot.");
        }
    }

    public void OpenTreasureChamber()
    {
        if (PureOfHeart && RareIterm == "Relic Stone")
        {
            if (!HasSecretIncantation)
            {
                Debug.Log("You have  the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("The treasure is yours");
            }
        }
        else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }
}
