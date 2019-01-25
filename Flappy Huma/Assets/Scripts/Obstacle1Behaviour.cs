using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Behaviour : MonoBehaviour {


    // in script be Obstacle1 nesbat dade shode ast
    // shamel 3 raftar mishavad aval sorat dovom destroy shodan sevom mahal e gharar giri beyne sibling ha ba siblingindex


    // moteghayer marboot be position chon canvas ast
    private RectTransform Obstacle1RectPos;



    // Use this for initialization
    void Start () {

        // dar ebteda tarif mikonim ke hamvare sevomin sibling bashad
        transform.SetSiblingIndex(2);

        // component rect transform ra farakhani kon
        Obstacle1RectPos = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {

        // yek bordar sorat ba moshakhase zir darim
        Vector3 v = new Vector3(-0.9f, 0, 0);


       

        // dar jahat bordar v va tebgh nerkh frame ha jabe jayi ra anjam bede
        transform.Translate(v * Time.deltaTime);


        // script destroy shodan
        if (Obstacle1RectPos.anchoredPosition.x < -1527)
        {
            Destroy(gameObject, 0);
        }


    }
}
