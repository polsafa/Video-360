using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisapear : ObjectDisableOnClick
{

    private void Awake()
    {
        GameManager.instance.playFX(audioFX.ERROR);
    }
    public override void onclick()
    {
        
        VRmanager.instance.playVideo();
    }
}
