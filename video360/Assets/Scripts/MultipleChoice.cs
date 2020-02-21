using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoice : ObjectWithCooldown
{
    public override void onclick()
    {
        VRmanager.instance.multiChoice();   
    }
}
