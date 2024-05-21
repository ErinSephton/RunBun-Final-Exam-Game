using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Dictionary to map sprite to its corresponding value
    private Dictionary<Sprite, int> spriteToValueMap;

    // Player number to identify which player this dice belongs to
    public int playerNumber;

    // Dice number to identify which dice this is for the player
    public int diceNumber;

    // Static arrays to hold the values of the dice rolls
    private static int[] player1DiceValues = new int[3];
    private static int[] player2DiceValues = new int[3];

    // Use this for initialization
    private void Start()
    {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");

        // Initialize the dictionary to map sprites to their values
        spriteToValueMap = new Dictionary<Sprite, int>();

        // Assign values to each sprite
        for (int i = 0; i < diceSides.Length; i++)
        {
            spriteToValueMap[diceSides[i]] = i + 1;
        }
    }

    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        int randomDiceSide;

        // Loop to switch dice sides randomly
        // before final side appears. 20 iterations here.
        for (int i = 0; i < 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next iteration
            yield return new WaitForSeconds(0.3f);
        }

        // Assigning final side based on the sprite
        int finalSide = spriteToValueMap[rend.sprite];

        // Store the dice value in the appropriate array
        if (playerNumber == 1)
        {
            player1DiceValues[diceNumber - 1] = finalSide;
        }
        else if (playerNumber == 2)
        {
            player2DiceValues[diceNumber - 1] = finalSide;
        }

        // Check if all dice for the player have been rolled
        if (AllDiceRolled(playerNumber))
        {
            int sum = CalculateSum(playerNumber);
            Debug.Log("Player " + playerNumber + " rolled a total of " + sum);

            if (sum > 10)
            {
                Debug.Log("Player " + playerNumber + " rolled above 10.");
            }
            else
            {
                Debug.Log("Player " + playerNumber + " rolled below 10.");
            }

            // Reset dice values for the next roll
            ResetDiceValues(playerNumber);
        }
    }

    private bool AllDiceRolled(int player)
    {
        if (player == 1)
        {
            foreach (int value in player1DiceValues)
            {
                if (value == 0)
                    return false;
            }
        }
        else if (player == 2)
        {
            foreach (int value in player2DiceValues)
            {
                if (value == 0)
                    return false;
            }
        }
        return true;
    }

    private int CalculateSum(int player)
    {
        int sum = 0;
        if (player == 1)
        {
            foreach (int value in player1DiceValues)
            {
                sum += value;
            }
        }
        else if (player == 2)
        {
            foreach (int value in player2DiceValues)
            {
                sum += value;
            }
        }
        return sum;
    }

    private void ResetDiceValues(int player)
    {
        if (player == 1)
        {
            for (int i = 0; i < player1DiceValues.Length; i++)
            {
                player1DiceValues[i] = 0;
            }
        }
        else if (player == 2)
        {
            for (int i = 0; i < player2DiceValues.Length; i++)
            {
                player2DiceValues[i] = 0;
            }
        }
    }
}
