using SpawnManagerAnimal;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        scoreText.text = "Your score: " + score.ToString();
        SetHighScore();
    }

    public void RestartButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        BaseAnimal.playerScoreFeedAnimal = 0;
        SceneManager.LoadScene("GameScene");
    }

    private void SetHighScore()
    {
        if (BaseAnimal.playerScoreFeedAnimal > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", BaseAnimal.playerScoreFeedAnimal);
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }else highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
