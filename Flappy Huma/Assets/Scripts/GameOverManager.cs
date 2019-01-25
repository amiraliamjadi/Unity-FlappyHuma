using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameOverManager : MonoBehaviour {

    // in script be camera nesbat dade shode ast
    // vazife omoor marboot be game over shodan ra bar ohde darad


    // key marboot be faal shodan e method haye game over
    public int KeyToGameOver = 0;


    // etelaat marboote ra dakhel moteghayer az jens Ray mirizim
    private Ray raypos;

    // etelaat jesmi ke Ray be an barkhord karde be dakhel in mirizad
    private RaycastHit HitInformation;

    // GO haye marboot be Menu baraye on va off shodan
    public GameObject GameOverCanvasOff;

    // moteghayer marboot be khalgh e character bazi
    public GameObject CharacterRespawn;








    private void GameOverMethod()
    {
        // panel e game over zaher shavad
        GameOverCanvasOff.SetActive(true);

        // game ejra nashavad marahel ash
        FindObjectOfType<GameControl>().KeyToStartGame = 0;

        // bazi ra motevaghef kon
        Time.timeScale = 0;



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

                    // replay button
                    if (NameGO == "ReplayButton")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // seda bal zadan ra vasl kon
                        FindObjectOfType<AudioManager>().MusicVolumeUp("FlySound");

                        KeyToGameOver = 0;

                        // bazi be halat e harekat dar biyayad
                        Time.timeScale = 1;

                        // tamami object hayi ke clone shodan ra destroy kon
                        GameObject[] GOClonesDestroy = GameObject.FindGameObjectsWithTag("ReplayTagDestroy");
                        for (int i = 0; i < GOClonesDestroy.Length; i++)
                        {
                            Destroy(GOClonesDestroy[i]);
                        }


                        // panel e game over zaher shavad
                        GameOverCanvasOff.SetActive(false);

                        // character bazi ra khalgh kon
                        CharacterRespawn = Instantiate(Resources.Load("Huma"), new Vector3(-1.4f, 1, 0), Quaternion.identity) as GameObject;

                        // yek faaz khalgh shavad
                        FindObjectOfType<GameControl>().GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;

                        // score sefr shavad
                        FindObjectOfType<ScoreScript>().ScoreInteger = 0;

                        // key marboote be start game faal shavad
                        FindObjectOfType<GameControl>().KeyToStartGame = 1;


                        FindObjectOfType<ScoreScript>().NewImageHighScore.SetActive(false);



                    }


                    // leaderboard button
                    if (NameGO == "Leaderboard2Button")
                    {
                        // dastoor ejra sound click
                        FindObjectOfType<AudioManager>().Play("ClickSound");

                        // leaderboard command
                        FindObjectOfType<ScoreScript>().ShowLeaderboardsUI();

                    }


                }
            }
        }






    }




 





    // Use this for initialization
    void Awake () {

        // dar ebteda gheyre faal bash
        KeyToGameOver = 0;

        // dar ebteda naapadid bash
        GameOverCanvasOff.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if ( KeyToGameOver == 1)
        {
            GameOverMethod();
        }
		
	}
}
