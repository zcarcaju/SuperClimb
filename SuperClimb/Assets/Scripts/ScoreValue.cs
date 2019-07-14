
using UnityEngine;
using UnityEngine.UI;

public class ScoreValue : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text highScore;
    public int high;
    public int temp;
 
    void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }
    void Update()
    {
        score.text = Player.position.y.ToString("0");

        if (int.Parse(score.text) >= int.Parse(highScore.text))
        {
            highScore.text = score.text;
            high = int.Parse(highScore.text);
            PlayerPrefs.SetInt("HighScore", high);
        }
        
    }
    void Test()
    {

        if (high > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", high);
            highScore.text = high.ToString();
        }

       
    }
  
}
