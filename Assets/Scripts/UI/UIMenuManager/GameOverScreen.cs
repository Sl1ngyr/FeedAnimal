using SpawnManagerAnimal;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private const string HIGH_SCORE_PREFS_KEY = "HighScore";
    
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
        if (BaseAnimal.playerScoreFeedAnimal > PlayerPrefs.GetInt(HIGH_SCORE_PREFS_KEY))
        {
            PlayerPrefs.SetInt(HIGH_SCORE_PREFS_KEY, BaseAnimal.playerScoreFeedAnimal);
            highScoreText.text = $"{HIGH_SCORE_PREFS_KEY}: " + PlayerPrefs.GetInt(HIGH_SCORE_PREFS_KEY);
        }
        else highScoreText.text = $"{HIGH_SCORE_PREFS_KEY}: " + PlayerPrefs.GetInt(HIGH_SCORE_PREFS_KEY);
    }
}
