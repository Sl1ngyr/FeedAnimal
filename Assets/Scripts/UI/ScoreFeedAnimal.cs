using SpawnManagerAnimal;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFeedAnimal : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
    private void OnEnable()
    {
        BaseAnimal.onScoreTextSet += SetScoreText;
    }
    
    private void OnDisable()
    {
        BaseAnimal.onScoreTextSet -= SetScoreText;
    }
    
    private void SetScoreText()
    {
        scoreText.text = $"Score: {Animal.playerScoreFeedAnimal.ToString()}";
    }
    
}
