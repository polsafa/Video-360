using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlay : ObjectDisableOnClick
{
    public override void onclick()
    {
        VRmanager.instance.playVideo();
    }
}
