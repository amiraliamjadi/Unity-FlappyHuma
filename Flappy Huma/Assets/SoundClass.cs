using UnityEngine.Audio;
using UnityEngine;

// baraye ghabele dasresi boodan dar inspector va erja dadan be script AudioManager
[System.Serializable]


// yek class kharej monobahaviour tarif kardim va ba script AudioManager ertebat midim
public class SoundClass
{


    // in ha dar menu inspector baraye har music ke element ash ra doros mikonim ghabele tanzim ast

    // name music marboote
    public string name;

    // ghabeliyat add kardan audio
    public AudioClip clip;


    // volume ( bozorgi seda ) beyne sefr va 1
    [Range(0f, 1f)]
    public float volume;
    // pitch ( ferekans e seda yani zir o baam shodan esh)
    [Range(.1f, 3)]
    public float pitch;

    // bara loop kardan music ha
    public bool loop;

    // bara mute kardan
    public bool mute;


    // mikhahim public va ghabele dasresi hame ja bashad vali dar inspector namayesh dade nashavad
    [HideInInspector]
    // moteghayer audiosource ra doros konim dar script audiomanager in ra farakhani mikonim ta audiosource farakhani konim
    public AudioSource source;


}
