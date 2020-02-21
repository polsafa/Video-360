using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public audioFX buttonclick, buttonplay;

    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = false;
    }

    public void buttonFX(audioFX fx = audioFX.CLICK)
    {
        GameManager.instance.playFX(fx);
    }

    public void buttonChangeScene()
    {
        buttonFX(buttonplay);
        SceneManager.LoadScene((int)scenes.VR);
    }

    public void ButtonClick()
    {
        buttonFX(buttonclick);
    }


}
