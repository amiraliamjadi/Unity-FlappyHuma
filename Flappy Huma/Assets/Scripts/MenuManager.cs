using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class MenuManager : MonoBehaviour {

    // in script marboot be menu ast
    // dokme play , leaderboard, insta , facebook , googleplay, blog ast
    // in script be camera nesbat dade shode ast


    // etelaat marboote ra dakhel moteghayer az jens Ray mirizim
    private Ray raypos;

    // etelaat jesmi ke Ray be an barkhord karde be dakhel in mirizad
    private RaycastHit HitInformation;

    // GO haye marboot be Menu va game play baraye on va off shodan
    public GameObject GamePlayCanvas1Off, GamePlayCanvas2Off , MenuCanvasOff, GameOverCanvas;


    // moteghayer marboot be khalgh e character bazi
    public GameObject CharacterRespawn;



    // unity ads
    string gameId = "3011435";
    bool testMode = false;



    // tabe marboot be dokme play ke agar bezanim bazi aghaz mishad
    // tabe marboot be dokme instagram ke agar bezanim mara be safe insta monkey jack (insta sherkat) mibarad
    // tabe marboot be dokme facebook ke agar bezanim mara be safe facebook monkey jack (facebook sherkat) mibarad
    // tabe marboot be dokme googleplay ke mara be panel googleplay sherkat mibarad
    // tabe marboot be dokme blog ke mara be blog e monkeyjack mibarad
    private void TapTouchControl()
    {
        if (Input.touchCount > 0)
        {
            // be ezaye aghaz e faz ( avalin touch ke anjam shod)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // position jayi ke angosht ma roo screen zade shod ra tabdil be Ray bokon va be moteghayer beriz
                raypos = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                // serfan khat farzi dar kharej bazi dar safe scene mikeshad ta amalkard ra bebinim
                Debug.DrawRay(raypos.origin, raypos.direction * 2000, Color.red);


                // agar barkhordi soorat gereft tavasot raypos etelaat ra be dakhel HitInformation beriz dar baze bi nahayat
                if (Physics.Raycast(raypos, out HitInformation, Mathf.Infinity))
                {
                    // hal ke be etelaat jesm barkhord shode dastresi darim name ash ra be string marboote beriz
                    string NameGO = HitInformation.collider.gameObject.name;

                    // play button
                    if ( NameGO == "PlayButton")
                    {
                        // anasor e menu mahv shavad va gamplay aghaz shavad shavad va game over ghat bashad
                        MenuCanvasOff.SetActive(false);
                        GamePlayCanvas1Off.SetActive(true);
                        GamePlayCanvas2Off.SetActive(true);
                        GameOverCanvas.SetActive(false);

                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // character bazi ra khalgh kon
                        CharacterRespawn = Instantiate(Resources.Load("Huma"), new Vector3(-1.4f, 1, 0), Quaternion.identity) as GameObject;


                        // key marboote be start game faal shavad
                        FindObjectOfType<GameControl>().KeyToStartGame = 1;


                    }

                    // leaderboard button
                    if (NameGO == "LeaderboardButton")
                    {

                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // leaderboard command
                        FindObjectOfType<ScoreScript>().ShowLeaderboardsUI();



                    }

                    // instagram button
                    if (NameGO == "InstagramButton")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // mara be link instagram sherkat mibarad
                        Application.OpenURL("https://www.instagram.com/monkey.jack/");

                    }

                    // facebook button
                    if (NameGO == "FacebookButton")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // mara be safe facebook company mibarad
                        Application.OpenURL("https://www.facebook.com/MonkeyJack.group");
                        
                    }

                    // google play button
                    if (NameGO == "GoogleplayButton")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // googleplay command
                    }

                    // blog button
                    if (NameGO == "BlogButton")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // mara be blog e monkey bebar
                        Application.OpenURL("http://monkeyjackgroup.blogspot.com/2019/01/flappy-huma.html");
                    }

                }
            }
        }
    }







    // Use this for initialization
    void Start () {

        // anasor e menu zaher shavand
        MenuCanvasOff.SetActive(true);
        GamePlayCanvas1Off.SetActive(false);
        GamePlayCanvas2Off.SetActive(false);
        GameOverCanvas.SetActive(false);

        // unity ads

        // video
        Monetization.Initialize(gameId, testMode);


    }
	
	// Update is called once per frame
	void Update () {

        // tabe marboot be dokme menu asli ra ejra kon
        TapTouchControl();

    }
}
