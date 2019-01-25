using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesBehaviour : MonoBehaviour {

    // script ke be hame anva e pipes ha nesbat dade mishavad ke sorat va destroy shodan e an ha ra bayan mikonad



	
	// Update is called once per frame
	void Update () {

         // yek bordar sorat ba moshakhase zir darim
         Vector3 v = new Vector3(-1.9f, 0, 0);
       

        // dar jahat bordar v va tebgh nerkh frame ha jabe jayi ra anjam bede
        transform.Translate(v * Time.deltaTime);


        // kamtar az fasele shod destroy kon object ra
        if (transform.position.x < -4f)
        {
            Destroy(gameObject, 0);
        }

    }
}
