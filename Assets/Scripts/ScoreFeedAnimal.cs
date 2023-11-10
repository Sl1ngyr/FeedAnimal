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
        textScore.SetStartText($"Score: {DetectCollision.count.ToString()}");
        score = DetectCollision.count;
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectCollision.count > score)
        {
            textScore.setScoreText($"Score: {DetectCollision.count.ToString()}");
            score = DetectCollision.count;
        }
    }
}
