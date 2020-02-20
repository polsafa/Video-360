using UnityEngine;

    public class ObjectDisableOnClick : ObjectInteractable
    {
        public override void actionAfterClick()
        {
            gameObject.SetActive(false);
        }
    }

