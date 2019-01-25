using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe3Behaviour : MonoBehaviour {

    // in script be pipe3 va zir majmoe pipe broken e dynamic ke rigidbody ast nesbat dade shode ast
    // shamel e shoru shodan e soghoot ast va age be pipe e payin khord freeze mishavad



    // jesm solb boodan pipe broken ke vijegi barkhord va soghoot ra ijad mikonad
    private Rigidbody2D RigidbodyBrokenPipe;

    // dastoorat key ha
    public int KeyToStartBreak = 0, KeyToFreeze = 1;


    // Use this for initialization
    void Start () {

        // farakhani kon anasor e jesm e solb ra
        RigidbodyBrokenPipe = GetComponent<Rigidbody2D>();

        // ta be start nakhorde code haro ejra nakon
        KeyToStartBreak = 0;

        // ebteda freeze bashe rigidbody ke harekat nakonad
        RigidbodyBrokenPipe.gravityScale = 0;

        // dar ebteda in key faal bashad ta dar payin ke yebar tag anjam shod update ghofl shavad
        KeyToFreeze = 1;

    }
	
	// Update is called once per frame
	void Update () {

        // agar key faal shod
        if ( KeyToStartBreak == 1)
        {
            // agar key faal bood ( agar be collider bokhorad key gheyre faal mishavad)
            if ( KeyToFreeze == 1)
            {
                // rigidbody ra be kar bendaz ta soghoot kone va bar ham konesh dashte bashe
                RigidbodyBrokenPipe.gravityScale = 2;
            }
            
        }

		
	}


    private void OnTriggerEnter2D(Collider2D col)
    {
        // agar be tag e marboot be freeze shodan resid
        if (col.gameObject.tag == "FreezeZoneTag")
        {
            // sedaye barkhord
            FindObjectOfType<AudioManager>().Play("BrokenFallSound");

            // freeze sho
            KeyToFreeze = 0;
            RigidbodyBrokenPipe.gravityScale = 0;
            RigidbodyBrokenPipe.velocity = new Vector3(0, 0, 0);
        }


    }

 }
