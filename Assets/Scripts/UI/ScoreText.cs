using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] protected Text scoreText;

        protected int score;
        // Start is called before the first frame update

        protected void SetStartText(string textStart)
        {
            scoreText.text = textStart;
        }

        protected void SetScoreText(string textScore)
        {
            scoreText.text = textScore;
        }
    }
}