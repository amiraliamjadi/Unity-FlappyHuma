using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ScoreScript : MonoBehaviour {

    // in script be camera nesbat dade shode ast
    // tamami e score ha highscore ha inja modiriyat mishavand

    // anasor e UI score ha
    public TextMeshProUGUI HighscoreText, ScoreText, GameOverScoreNumberText, GameOverHighScoreNumberText;

    // shomarande e emtiyaz ha
    public int ScoreInteger = 0;

    public GameObject NewImageHighScore;



    //////////////////////////////////////////////////////////////////////////////////

    // reset high score
    // yek tabe ast ke masalan be yek dokme nesbat midahim ta farakhani shavad
    // public void Reset()
    // {
    // PlayerPrefs.DeleteKey("HighScoreKey");
    // }

    ///////////////////////////////////////////////////////////////////////////////////



    // Use this for initialization
    void Start () {

        // dar ebteda emtiyaz sefr ast
        ScoreInteger = 0;

        // dar menu dar ebteda highscore namayesh dade shavad
        HighscoreText.text = PlayerPrefs.GetInt("HighScoreKey", 0).ToString();

        NewImageHighScore.SetActive(false);


        // dastoorat marboot be leaderboard google

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();

    }


    // method baraye sign in kardan be leaderboard google
    void SignIn()
    {
        Social.localUser.Authenticate( (bool success) => { } );
    }

    // dastoorat marboot be ertebat va namayesh e leaderboard
 
    // method e marboot be neshan dadan e UI ash
    public void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }



    // Update is called once per frame
    void Update () {

        // dakhel e bazi emtiyaz ha ra beshmor
        ScoreText.text = ScoreInteger.ToString();

        // agar emtiyaz kasb shode bishtar az adad highscore bood
        if (ScoreInteger > PlayerPrefs.GetInt("HighScoreKey", 0))
        {
            // an adad marboote ra tebgh yek code shenase khas dakhel barname zakhire kon
            PlayerPrefs.SetInt("HighScoreKey", ScoreInteger);


            // be leaderboard google sync sho va meghdar e highscore ra gharar bede
            Social.ReportScore(ScoreInteger, GPGSIds.leaderboard_highscore, (bool success) => { });

            // image new o biyar ta neshan dahad highscore jadid darad
            NewImageHighScore.SetActive(true);
        }

        

        // dar panel e game over score ra namayesh bede
        GameOverScoreNumberText.text = ScoreText.text;

        // dar panel e game over meghdar e highscore namayesh dade shavad
        GameOverHighScoreNumberText.text = PlayerPrefs.GetInt("HighScoreKey").ToString();

        // dar menu highscore ra namayesh bede
        HighscoreText.text = PlayerPrefs.GetInt("HighScoreKey").ToString();



       // Reset();


    }
}
