using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        pointText.text = "Your score: " + score.ToString();
    }

    public void RestartButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game Restart");
        SceneManager.LoadScene("GameScene");
    }
    
    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}
