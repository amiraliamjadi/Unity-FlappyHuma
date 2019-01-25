using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectsSpawn : MonoBehaviour {


    // in script be camera nesbat dade shode ast
    // marboot be obstacle ha va object haye background ke parallax daran hast ha ast ke be soorat e image child e canvas hastan
    // anha hatman bayad beyne dota az background ha bashan ta doros ejra shavand ke dar script behave be an pardakhte shode
    // hamchenin sorat va destroy anha dar script behave mojud ast



    // moteghayer marboot be ostacle 1 va 2 va ground ast
    public GameObject Obstacle1, Obstacle2 , Ground;


    // tabe marboot be khalgh obstacles va ground
    private void ObstaclesSpawnMethod()
    {
        // obstacle 1:

        // agar az mokhtasat marboote kamtar shod
        if (Obstacle1.transform.position.x < 0)
        {

            // amal khalgh ra dar position e balatar anjam bede be dakhel moteghayer beriz
            Obstacle1 = Instantiate(Resources.Load("Obstacles1"), new Vector3(1527, -719, 0), Quaternion.identity) as GameObject;

            // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
            Obstacle1.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas1Tag").transform, false);

        }

        // obstacle 2:

        // agaraz mokhtasat marboote kamtar shod
        if (Obstacle2.transform.position.x < 0)
        {

            // amal khalgh ra dar position e balatar anjam bede be dakhel moteghayer beriz
            Obstacle2 = Instantiate(Resources.Load("Obstacles2"), new Vector3(1374, -590, 0), Quaternion.identity) as GameObject;

            // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
            Obstacle2.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas1Tag").transform, false);

        }

        // ground:

        // agar tag marboote ra dasht va az mokhtasat marboote kamtar shod
        if (Ground.transform.position.x < 0)
        {

            // amal khalgh ra dar position e balatar anjam bede be dakhel moteghayer beriz
            Ground = Instantiate(Resources.Load("Ground"), new Vector3(2261, -1003, 0), Quaternion.identity) as GameObject;

            // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
            Ground.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas2Tag").transform, false);

        }


    }




    // Use this for initialization
    // elati ke awake etefagh oftad in ast ke ghable start ke canvas haro set active ra false konim
    // amal e anjam e avaliye khalgh shodan doros shode bashad
    // tavajoh konid ke dar heirachy set active on bashad hatman baraye dota canvas e gameplay
    void Awake () {

        // obstacle 1:

        // dar ebteda dar mabda khalgh kon
        Obstacle1 = Instantiate(Resources.Load("Obstacles1"), new Vector3(0, -719, 0), Quaternion.identity) as GameObject;

        // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
        Obstacle1.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas1Tag").transform, false);

        // obstacle 2:

        // dar ebteda dar mabda khalgh kon
        Obstacle2 = Instantiate(Resources.Load("Obstacles2"), new Vector3(0, -590, 0), Quaternion.identity) as GameObject;

        // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
        Obstacle2.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas1Tag").transform, false);

        // ground:

        // dar ebteda dar mabda khalgh kon
        Ground = Instantiate(Resources.Load("Ground"), new Vector3(0, -1003, 0), Quaternion.identity) as GameObject;

        // canvas daraye tag ast migooyim shey khalgh shode child e canvas ( parent ) beshavad
        Ground.transform.SetParent(GameObject.FindGameObjectWithTag("GameCanvas2Tag").transform, false);

    }
	
	// Update is called once per frame
	void Update () {

        // tabe marboot be BIG ejra shavad
        ObstaclesSpawnMethod();

    }
}
