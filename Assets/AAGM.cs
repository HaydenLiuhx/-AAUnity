using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AAGM : MonoBehaviour
{
    public static int score = 0;
    public Text ScoreText;

    public string NextLevelName;

    public int gold = 6;
    // Start is called before the first frame update
    void Start()
    {
        score = gold;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score + "";

        if(score == 0)
        {
            //next lv
            SceneManager.LoadScene(NextLevelName);
        }
        
    }
}
