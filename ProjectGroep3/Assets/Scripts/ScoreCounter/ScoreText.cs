using Score;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    //----------------------Private----------------------//
    private TMP_Text text;

    //----------------------Functions----------------------//
    private void Start() => text = GetComponent<TMP_Text>();

    private void LateUpdate() => text.text = "Score: " + (int)ScoreCounter.Instance.Score;
}
