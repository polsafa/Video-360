using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGoMenu : ObjectWithCooldown
{
    public override void onclick()
    {
        SceneManager.LoadScene((int) scenes.MENU);
    }
}
