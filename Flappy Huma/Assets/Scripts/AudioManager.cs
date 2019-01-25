using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{



    public SoundClass[] sounds;


    // baraye inke yedune audio manager sabet too har scene dashte bashim
    public static AudioManager instance;



    // Use this for initialization
    void Awake()
    {

        // baraye inke faghat yedune audiomanager dashte bashim va age asan audiomanager E nabud return kon
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // baraye inke audiomanager dar scene haye badi niz biyayad va seda aslan ghat nashavad
        // va mostaghel az taghir e scene ejra shavad
        DontDestroyOnLoad(gameObject);


        foreach (SoundClass s in sounds)
        {
            // add kon component e source o 
            s.source = gameObject.AddComponent<AudioSource>();

            // clip ash barabar clip sound e marboote bashad
            s.source.clip = s.clip;

            // volume ash barabar volume khode sound e marboote bashad
            s.source.volume = s.volume;

            // pitch ash barabar e pitch e khode sound bashad
            s.source.pitch = s.pitch;

            // loop ra barabar e loop e music gharar bede ( tekrar shavad ya na)
            s.source.loop = s.loop;

            // mute ra barabar e mute boodan ya nabudan music gharar bede
            s.source.mute = s.mute;

        }


    }



    public void Play(string name)
    {
        // araye haye sounds o begard va name marboote ra peyda kon be dakhel moteghayer s ke too class soundclass ast beriz
        SoundClass s = Array.Find(sounds, sound => sound.name == name);

        // agar string name eshteba vared shavad etefaghi nayoftad
        if (s == null)
            return;

        // har moghe dar morede sound E ke name ash avarde mishavad dastoor play kardan ra ejra kon
        s.source.Play();
    }



    public void Stop(string name)
    {
        // araye haye sounds o begard va name marboote ra peyda kon be dakhel moteghayer s ke too class soundclass ast beriz
        SoundClass s = Array.Find(sounds, sound => sound.name == name);

        // agar string name eshteba vared shavad etefaghi nayoftad
        if (s == null)
            return;

        // har moghe dar morede sound E ke name ash avarde mishavad dastoor stop kardan ra ejra kon
        s.source.Stop();
    }



    // baraye ziyad kardan volume estefade misgavad
    public void MusicVolumeUp(string name)
    {
        // araye haye sounds o begard va name marboote ra peyda kon be dakhel moteghayer s ke too class soundclass ast beriz
        SoundClass s = Array.Find(sounds, sound => sound.name == name);

        // agar string name eshteba vared shavad etefaghi nayoftad
        if (s == null)
            return;

        s.source.volume = 1f;

    }

    // baraye kam kardan volume estefade mishavad
    public void MusicVolumeDown(string name)
    {
        // araye haye sounds o begard va name marboote ra peyda kon be dakhel moteghayer s ke too class soundclass ast beriz
        SoundClass s = Array.Find(sounds, sound => sound.name == name);

        // agar string name eshteba vared shavad etefaghi nayoftad
        if (s == null)
            return;

        s.source.volume = 0;

    }


}
