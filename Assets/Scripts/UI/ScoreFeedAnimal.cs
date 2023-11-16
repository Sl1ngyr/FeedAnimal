using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFeedAnimal : MonoBehaviour
{
    public SetTextScore textScore;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        textScore.SetStartText($"Score: {Animal.scorePlayerFeedAnimal.ToString()}");
        score = Animal.scorePlayerFeedAnimal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Animal.scorePlayerFeedAnimal > score)
        {
            textScore.SetScoreText($"Score: {Animal.scorePlayerFeedAnimal.ToString()}");
            score = Animal.scorePlayerFeedAnimal;
        }
    }
}
