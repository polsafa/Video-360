using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : ObjectWithCooldown
{
    // Start is called before the first frame update
    public override void onclick()
    {
        SceneManager.LoadScene((int)scenes.VR);
    }
}
