using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IObjectInteractable target;

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit, Mathf.Infinity))
        {
            IObjectInteractable objectHit = hit.collider.GetComponent<IObjectInteractable>();

            if(objectHit != target)
            {
                if (target != null)
                    target.resetCount();
             
                target = objectHit;

            }

            target.selected();
        }
        else
        {
            if (target != null)
            {
                target.resetCount();
                target = null;
            }

        }
    }
}
