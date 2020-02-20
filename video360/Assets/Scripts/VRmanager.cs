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


    private double totaltime, currenttime;
    private VideoPlayer vrplayer;
    private byte currentevent;

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

    private void getcurrenttime()
    {
        if(timeEvents.Count > 0 && timeEvents.Count > currentevent)
        {
            if(timeEvents[currentevent].time <= currentevent)
            {
                timeEvents[currentevent].obj.SetActive(true);
                currentevent++;
                vrplayer.Pause();
            }
        }
    }
}
