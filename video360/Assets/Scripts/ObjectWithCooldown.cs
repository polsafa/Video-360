using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithCooldown : ObjectInteractable
{
       public override void actionAfterClick()
    {
        StartCoroutine(EnableAfterSeconds());
    }
}

