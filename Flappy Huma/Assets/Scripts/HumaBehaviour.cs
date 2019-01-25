using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;


[RequireComponent(typeof(Rigidbody2D))]
public class HumaBehaviour : MonoBehaviour {

    // in script be huma nesbat dade shode ast
    // shamel paresh va charkhesh va animation haye baal zadan va mordan mishavad
    // baraye score va mordan tavasot e collider ha anjam mishavad




    // meghdar niroo lazem vaghti tap kardim be huma midahad
    public float TapForce = 240;
    // smooth boodan charkhesh hengam soghoot
    public float TiltSmooth = 0.6f;

    // jesm solb boodan huma ke vijegi barkhord va soghoot ra ijad mikonad
    private Rigidbody2D RigidbodyHuma;

    // charkhesh roo be payin va charkhesh roo bala
    Quaternion UpRotation, DownRotation;


    // animation
    public Animator FlyAnime, DeadAnime;


    public GameObject Pipe3StartBreakGO;




    // unity ads
    public string placementId = "video";

    private int AdCounter = 0;





    // method marboot be inke bade inke baal zadan ejra shod ba invoke method farakhani mishavad
    // va migooyim amal e baal zadan motevaghef shavad
    private void FlyAnimeMethod()
    {
        FlyAnime.SetBool("AnimeBool", true);
    }


    // Use this for initialization
    void Start () {

        // animation e mordan dar ebteda ejra nashavad
        DeadAnime = GetComponent<Animator>();
        DeadAnime.SetBool("DeadAnimeBool", false);

        // farakhani kon anasor e jesm e solb ra
        RigidbodyHuma = GetComponent<Rigidbody2D>();

        // meghdar haye zaviye E charkhesh e huma hengam e tap va soghoot
        DownRotation = Quaternion.Euler(0, 0, -90);
        UpRotation = Quaternion.Euler(0, 0, 25);

        // animation ra farakhani kon
        FlyAnime = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        // dastoorat marboot be tap kardan ke mojeb paresh huma mishavad
        if (Input.touchCount > 0)
        {
            // be ezaye aghaz e faz ( avalin touch ke anjam shod )
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // dastoor ejra sound fly kardan
                FindObjectOfType<AudioManager>().Play("FlySound");

                // be zaviye khaste shode rotate kon
                transform.rotation = UpRotation;

                // dobare sorat charkhesh haman default shavad
                TiltSmooth = 0.6f;

                // sorat e avaliye ra sefr kon
                RigidbodyHuma.velocity = Vector3.zero;

                // niroo vared kon ta be bala ravad
                RigidbodyHuma.AddForce(Vector2.up * TapForce , ForceMode2D.Force);

                // animation baal zadan ejra shavad
                FlyAnime.SetBool("AnimeBool", false);
                // bade 0.5 saniye motevaghef shavad
                Invoke("FlyAnimeMethod", 0.2f);

            }
        }

      

        // charkhesh e roo be payin ra anjam bede
        transform.rotation = Quaternion.Lerp(transform.rotation, DownRotation, TiltSmooth * Time.deltaTime);

        // be moroor sorat e charkhesh ziyad shavad
        TiltSmooth += 0.01f;


        // shart baraye inke az bala az kadr az kharej nashavad
        if (transform.position.y >= 5.01)
        {

            transform.position = new Vector3(-1.4f, 5, 0);
        }



    }




    // method marboot be faal shodan e key game over 
    private void GameOverDead()
    {
        FindObjectOfType<GameOverManager>().KeyToGameOver = 1;
    }





    // unity ads

    // show ads function
    public void ShowAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    // store the ad
    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }







    // bakhsh barkhord ba collider ha
    private void OnTriggerEnter2D(Collider2D col)
    {
        // agar dar nahiye ke tag on score darad raftim va collide kardim
        // ke beyne loole ha in nahiye ast ke emtiyaz migirim
        if ( col.gameObject.tag == "ScoreZoneTag")
        {
            // yedune be score ezafe kon
            FindObjectOfType<ScoreScript>().ScoreInteger++;

            // music score ra play kon
            FindObjectOfType<AudioManager>().Play("PointSound");

        }

        // agar be tag haye dead khord ke shamel zamin ( ground collider ) va sotun ha ( pipes ) mishavad
        if (col.gameObject.tag == "DeadZoneTag")
        {
            // music e barkhord
            FindObjectOfType<AudioManager>().Play("HitSound");

            // freeze kon rigidbody ra
            RigidbodyHuma.simulated = false;

            // animation e mordan ra ejra kon
            DeadAnime.SetBool("DeadAnimeBool", true);

            // seda bal zadan ra ghat kon
            FindObjectOfType<AudioManager>().MusicVolumeDown("FlySound");



            // unity ads

            // meghdari ke save ast ra be dakhel moteghayer int beriz
            AdCounter = PlayerPrefs.GetInt("AdCounterKey");

            // yek dune be meghdar ezafe kon ta yeki az halat ha ejra shavad
            AdCounter++;

            // in adad e halat ra save kon
            PlayerPrefs.SetInt("AdCounterKey", AdCounter);


            // agar adad 1 shod hichi neshan nade
            if (PlayerPrefs.GetInt("AdCounterKey") == 1)
            {

                // hichi neshun nade

            }

            // dafe dovom ke game over shod hichi neshan nade
            if (PlayerPrefs.GetInt("AdCounterKey") == 2)
            {

                // hichi neshun nade

            }


            // video neshan bede
            if (PlayerPrefs.GetInt("AdCounterKey") == 3)
            {
                // dar akhar dobare be adad e sefr e avaliye bargard ta dobare in process anjam shavad
                PlayerPrefs.SetInt("AdCounterKey", 0);

                // ad unity
                // video neshun bede
                ShowAd();
            }



            // ba takhir e yek saniye dastoor e faal shodan e key game over ra bede
            Invoke("GameOverDead", 0.6f);

        }

        // marboot be pipe3 baraye start e break
        if ( col.gameObject.tag == "StartBrokenTag")
        {
            // az in object ke peyda kardi collider ash ra parent ash ra peyda kon sepas dovomin child ash
            // ra peyda kon ke mishavad rigidbody e mad e nazar e ma ke soghoot mikhahad bokonad
            Pipe3StartBreakGO = col.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;

            // be code ha dastresi peyda kon
            // mojavez e soghoot ra faghat be hamin rigidbody bede
            Pipe3StartBreakGO.GetComponent<Pipe3Behaviour>().KeyToStartBreak = 1;
        }


    }





}
