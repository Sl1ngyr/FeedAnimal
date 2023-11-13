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
        textScore.SetStartText($"Score: {Animal.count.ToString()}");
        score = Animal.count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Animal.count > score)
        {
            textScore.setScoreText($"Score: {Animal.count.ToString()}");
            score = Animal.count;
        }
    }
}
