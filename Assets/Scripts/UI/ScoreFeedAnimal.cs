using UI;
public class ScoreFeedAnimal : ScoreText
{
    void Start()
    {
        SetStartText($"Score: {Animal.scorePlayerFeedAnimal.ToString()}");
        score = Animal.scorePlayerFeedAnimal;
    }
    
    void Update()
    {
        if (Animal.scorePlayerFeedAnimal > score)
        {
            SetScoreText($"Score: {Animal.scorePlayerFeedAnimal.ToString()}");
            score = Animal.scorePlayerFeedAnimal;
        }
    }
}
