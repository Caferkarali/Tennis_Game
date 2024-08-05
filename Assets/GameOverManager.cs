using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText; // UI Text bileþeni referansý
    private bool gameOver; // Oyun bitip bitmediðini takip eden deðiþken

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Oyunun baþýnda yazýyý gizle
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
        gameOverText.gameObject.SetActive(true); // Oyun bittiðinde yazýyý göster
        gameOver = true;
    }

    void RestartGame()
    {
        // Þu anki sahneyi yeniden yükleyerek oyunu resetle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
