using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText; // UI Text bile�eni referans�
    private bool gameOver; // Oyun bitip bitmedi�ini takip eden de�i�ken

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Oyunun ba��nda yaz�y� gizle
        gameOver = false;
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Oyun bitti�inde yaz�y� g�ster
        gameOver = true;
    }

    void RestartGame()
    {
        // �u anki sahneyi yeniden y�kleyerek oyunu resetle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
