using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextScore : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update

    public void SetStartText(string textStart)
    {
        text.text = textStart;
    }

    public void SetScoreText(string textScore)
    {
        text.text = textScore;
    }
    
}
