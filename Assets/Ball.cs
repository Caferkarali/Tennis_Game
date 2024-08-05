using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Vector3 initialPos; // ball's initial position

    int playerScore;
    int botScore;

    [SerializeField] Text playerScoreText;
    [SerializeField] Text botScoreText;

    private void Start()
    {
        initialPos = transform.position; // default it to where we first place it in the scene
        UpdateScores(); // Initialize the scores display
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Out")) // if the ball hits a wall
        {
            if (IsPlayerSide(collision)) // Check if the ball hits the player's side
            {
                botScore += 5;
            }
            else // Otherwise, it's the bot's side
            {
                playerScore += 5;
            }

            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset its velocity to 0 so it doesn't move anymore
            transform.position = initialPos; // reset its position 
            UpdateScores(); // Update the scores display

            // Oyun bittiğinde GameOver metodunu çağır
            FindObjectOfType<GameOverManager>().GameOver();
        }
    }

    bool IsPlayerSide(Collision collision)
    {
        // Implement logic to determine if the ball hit the player's side or bot's side
        // For example, check the position of the collision or use specific tags for player's and bot's walls
        return collision.transform.CompareTag("Out");
    }

    void UpdateScores()
    {
        playerScoreText.text = "Player: " + playerScore;
        botScoreText.text = "Bot: " + botScore;
    }
}
