using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


[System.Serializable]
public class TimeEvent
{
    public float time;
    public GameObject obj;
}

public class VRmanager : MonoBehaviour
{
    public List<TimeEvent> timeEvents = new List<TimeEvent>();
    public Slider slider;
    public static VRmanager instance;
    public GameObject change;
    public GameObject play, pause;
    public float timestoped;
    public double totaltime, currenttime;
    public VideoPlayer vrplayer;
    public byte currentevent;

    private void Awake()
    {

        change = play;
        UnityEngine.XR.XRSettings.enabled = true;
        if (instance == null)
            instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        vrplayer = GetComponent<VideoPlayer>();
        totaltime = vrplayer.clip.length;
        currentevent = 0;

        timeEvents.Sort((i, j) => i.time.CompareTo(j.time));
        realoadvideo();
    }

    public void playVideo()
    {
        if (vrplayer.isPlaying)
        {
            vrplayer.Stop();
        }
        vrplayer.Play();
    }
    public void playVideo(float time)
    {

        vrplayer.Play();
        vrplayer.time = time;

    }
    public void realoadvideo()
    {
        vrplayer.Stop();
        currentevent = 0;
        for(int i = 0; i < timeEvents.Count; i++)
        {
            timeEvents[i].obj.SetActive(false);
        }
        playVideo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (vrplayer.isPlaying)
        {   
            currenttime = vrplayer.time;
            getcurrenttime();
            slider.value = (float)(currenttime / totaltime);
        }

    }
    public void multiChoice()
    {
        
        if (vrplayer.isPlaying)
        {
            play.SetActive(false);
            change = pause;
            activeRaoutine();
            vrplayer.Stop();
            timestoped = (float) currenttime;
        }
        else
        {
            pause.SetActive(false);
            change = play;
            activeRaoutine();
            VRmanager.instance.playVideo(timestoped); 
        }
        
    }

    public void havedelay()
    {
        change.SetActive(true);
    }
   
    private void getcurrenttime()
    {
        if(timeEvents.Count > 0 && timeEvents.Count > currentevent)
        {
            if(timeEvents[currentevent].time <= currenttime)
            {
                timeEvents[currentevent].obj.SetActive(true);
                currentevent++;
                vrplayer.Pause();
            }
        }
    }

    public void activeRaoutine()
    {
        StartCoroutine(ActiveButton());
    }

    public IEnumerator ActiveButton()
    {
       
        yield return new WaitForSeconds(1);
        havedelay();
    }
}
