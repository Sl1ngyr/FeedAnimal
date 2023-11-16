using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameOverScoreFeedAnimal : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        SetScoreText();
    }

    void SetScoreText()
    {
        text.text = $"Your Score: {Animal.scorePlayerFeedAnimal.ToString()}";
    }
}
