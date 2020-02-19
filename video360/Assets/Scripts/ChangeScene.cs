using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public audioFX fx;
    public scenes scenetogo;

  public void onClick()
    {
        GameManager.instance.playFX(fx);
        SceneManager.LoadScene((int) scenetogo);
    }
}
