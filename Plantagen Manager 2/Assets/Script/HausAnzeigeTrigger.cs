using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausAnzeigeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject e;
    [SerializeField] private bool active = false;
    [SerializeField] private MonoBehaviour player;

    [SerializeField] private bool haus1;
    [SerializeField] private bool haus2;
    [SerializeField] private bool haus3;
    [SerializeField] private bool kontrollZentrum;

    [SerializeField] private GameObject haus1Panel;
    [SerializeField] private GameObject haus2Panel;
    [SerializeField] private GameObject haus3Panel;
    [SerializeField] private GameObject kontrollZentrumPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = true;
            e.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = false;
            e.SetActive(false);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (haus1 && active)
            {
                haus1Panel.SetActive(true);
                e.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.enabled = false;
            }
            else if (haus2 && active)
            {
                haus2Panel.SetActive(true);
                e.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.enabled = false;
            }
            else if(haus3 && active)
            {
                haus3Panel.SetActive(true);
                e.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.enabled = false;
            }
            else if(kontrollZentrum && active) 
            {
                kontrollZentrumPanel.SetActive(true);
                e.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.enabled = false;
            }
        }
    }
}
