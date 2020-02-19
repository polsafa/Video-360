using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.instance.initialized)
            GameManager.instance.init();
        
    }

    
}
