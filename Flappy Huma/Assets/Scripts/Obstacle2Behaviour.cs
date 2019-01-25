using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Behaviour : MonoBehaviour {

    // in script be Obstacle2 nesbat dade shode ast
    // shamel 3 raftar mishavad aval sorat dovom destroy shodan sevom mahal e gharar giri beyne sibling ha ba siblingindex


    // moteghayer marboot be position chon canvas ast
    private RectTransform Obstacle2RectPos;




    // Use this for initialization
    void Start () {

        // dar ebteda tarif mikonim ke hamvare dovomin sibling bashad
        transform.SetSiblingIndex(1);

        // component rect transform ra farakhani kon
        Obstacle2RectPos = GetComponent<RectTransform>();


    }
	
	// Update is called once per frame
	void Update () {


        // yek bordar sorat ba moshakhase zir darim
        Vector3 v = new Vector3(-0.7f, 0, 0);



        // dar jahat bordar v va tebgh nerkh frame ha jabe jayi ra anjam bede
        transform.Translate(v * Time.deltaTime);


        // script destroy shodan
        if (Obstacle2RectPos.anchoredPosition.x < -1374)
        {
            Destroy(gameObject, 0);
        }



    }
}
