using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject PausePanel;
    bool IslnPause;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            IslnPause = !IslnPause;
        }

        if (!IslnPause)
        {
            PausePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (IslnPause)
        {
            PausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        
    }
}
