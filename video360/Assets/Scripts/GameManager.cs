using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum audioFX
{
    CLICK = 0,
    START  = 1
}

public enum scenes
{
    MENU = 0,
    VR = 1
}

//patron de programación singleton
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private AudioClip[] arrayFX;
    private AudioSource audioSource = null;
    

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newManager = new GameObject("Game Manager");
                _instance = newManager.AddComponent<GameManager>();
                            newManager.AddComponent<AudioSource>();
                DontDestroyOnLoad(newManager);
            }

            return _instance;
        }
    }

    public void init()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        arrayFX = Resources.LoadAll<AudioClip>("Audios/FX");
    }

    public  void playFX(audioFX fx)
    {
        if (audioSource == null)
            init();
            
        
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.PlayOneShot(arrayFX[(int) fx]);
    }
}
