using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    // in script be camera nesbat dade shode ast
    // pas az faal shodan e key dar menu dastoor e khalgh e pipe ha sader shode va
    // anva e pipe ha ke 3 tas be soorat e random ba y haye random khalgh mishavand



    // moteghayer marboot be shoru bazi
    public int KeyToStartGame = 0;

    // 3 no pipe darim ke in moteghayer be soorat  e random shomare pipe haro entekhab mikonad
    // tavajoh : chegali ehtemal fargh darad va momken ast bazi shomare ha tekrari bashad noe pipe an
    private int PipeSelector = 0;

    // range e y ke be random midahim va bar asas e an dar y e  motefavet khalgh mishavad
    private float Pipe1YRange = 0, Pipe2YRange = 0, Pipe3YRange = 0;

    // moteghayer marboot be khalgh e 3 no pipe va game phase
    public GameObject Pipe1, Pipe2, Pipe3, GamePhaseGO;



    // method gameplay
    private void GameMethod()
    {
        // fasele pipe ha az ham ra tayin mikonad
        if (GamePhaseGO.transform.position.x < 4f)
        {
            // be soorat e random yeki az anva e pipe ra entekhab mikonad
            PipeSelector = Random.Range(1, 7);

            if (PipeSelector == 1)
            {
                // pipe 1
                
                Pipe1YRange = Random.Range(-1.15f,3.2f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe1 = Instantiate(Resources.Load("Pipe1"), new Vector3(7.14f, Pipe1YRange, 0), Quaternion.identity) as GameObject;

            }

            if (PipeSelector == 2)
            {
                // pipe 1

                Pipe1YRange = Random.Range(-1.15f, 3.2f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe1 = Instantiate(Resources.Load("Pipe1"), new Vector3(7.14f, Pipe1YRange, 0), Quaternion.identity) as GameObject;

            }

            if (PipeSelector == 3)
            {
                // pipe 1

                Pipe1YRange = Random.Range(-1.15f, 3.2f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe1 = Instantiate(Resources.Load("Pipe1"), new Vector3(7.14f, Pipe1YRange, 0), Quaternion.identity) as GameObject;

            }

            if (PipeSelector == 4)
            {
                // pipe 2

                Pipe2YRange = Random.Range(-0.8f, 0.8f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe2 = Instantiate(Resources.Load("Pipe2"), new Vector3(7.14f, Pipe2YRange, 0), Quaternion.identity) as GameObject;

            }

            if (PipeSelector == 5)
            {
                // pipe 2

                Pipe2YRange = Random.Range(-0.8f, 0.8f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe2 = Instantiate(Resources.Load("Pipe2"), new Vector3(7.14f, Pipe2YRange, 0), Quaternion.identity) as GameObject;

            }

            if (PipeSelector == 6)
            {
                // pipe 3

                Pipe3YRange = Random.Range(-0.7f, 1.5f);

                GamePhaseGO = Instantiate(Resources.Load("GamePhase"), new Vector3(7.14f, 0, 0), Quaternion.identity) as GameObject;
                Pipe3 = Instantiate(Resources.Load("Pipe3"), new Vector3(7.14f, Pipe3YRange, 0), Quaternion.identity) as GameObject;

            }

        }
    }



	// Use this for initialization
	void Start () {

        // dar ebteda gameplay ejra nashavad
        KeyToStartGame = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        // age dar menu manager dastoor sader shod ejra sho
        if ( KeyToStartGame == 1)
        {
            GameMethod();
        }
		
	}
}
