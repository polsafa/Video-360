using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//patron de programación singleton
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private AudioClip[] arrayFX;
    private AudioSource audioSource;
    private bool initialez = false;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newManager = new GameObject("Game Manager");
                _instance = newManager.AddComponent<GameManager>();
                            newManager.AddComponent<AudioSource>();
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    public bool initialized  { get{ return initialez; }  }

    public void init()
    {
        initialez = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        arrayFX = Resources.LoadAll<AudioClip>("Audios/FX");
    }
}
