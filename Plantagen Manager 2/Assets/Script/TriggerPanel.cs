using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private MonoBehaviour player;
    [SerializeField] private GameObject e;
    [SerializeField] private bool active = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(true);
            active = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(false);
            active = false;
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(active) 
            {            
                panel.SetActive(true);
                player.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                e.SetActive(false);
            }
        }
    }
}
