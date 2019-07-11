using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreValue : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    public Text score;
    public string maxScore;
    public string currentScore;
    // Update is called once per frame

    private void Start()
    {

    }
    void Update()
    {
        score.text = Player.position.y.ToString("0");

    }
}
