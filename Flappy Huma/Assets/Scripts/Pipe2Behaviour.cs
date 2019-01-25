using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe2Behaviour : MonoBehaviour {

    // in script be pipe dovom nesbat dade shode ast 
    // baes harekat e bala va payin e pipe mishavad

    // sorat e harekat
    private float V = 0.8f;

    // postion e y pipe 2
    private float PosY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // y ra dakhel e moteghayer beriz
        PosY = transform.position.y;


        // agar beyne baze ha bood dastoor  e harekat ra ejra kon
        if ( PosY >= -0.8f && PosY <= 0.8f)
        {
            // be sar va tah resid alamat sorat bar aks shavad ta dar jahat aks harekat konad
            if ( PosY == 0.8f || PosY == -0.8f)
            {
                V = V * -1;
            }


            // yek bordar sorat ba moshakhase zir darim
            Vector3 v = new Vector3(0, V, 0);


            // dar jahat bordar v va tebgh nerkh frame ha jabe jayi ra anjam bede
            transform.Translate(v * Time.deltaTime);
        }

        // agar kharej e baze oftad baresh gardun be baze
        if ( PosY > 0.8f)
        {
            PosY = 0.8f;
            transform.position = new Vector3(transform.position.x, PosY, transform.position.z);
        }

        // agar kharej e baze oftad baresh gardun be baze
        if (PosY < -0.8f)
        {
            PosY = -0.8f;
            transform.position = new Vector3(transform.position.x, PosY, transform.position.z);
        }


    }
}
