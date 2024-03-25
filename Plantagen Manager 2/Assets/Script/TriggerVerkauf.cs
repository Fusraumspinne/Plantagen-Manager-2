using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVerkauf : MonoBehaviour
{
    [SerializeField] private bool active = false;
    [SerializeField] private GameObject verkaufMenu;
    [SerializeField] private GameObject e;
    [SerializeField] private MonoBehaviour player;
    [SerializeField] private MonoBehaviour spline;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Menu;

    public void Start()
    {
        animator.SetBool("Talk", false);
        animator.SetBool("Walk", true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Menu.activeSelf)
            {
                active = true;
                e.SetActive(true);
            }
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
        if(Input.GetKeyDown(KeyCode.E) && active)
        {
            if (!Menu.activeSelf)
            {
                e.SetActive(false);
                verkaufMenu.SetActive(true);
                spline.enabled = false;
                player.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                animator.SetBool("Walk", false);
                animator.SetBool("Talk", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (verkaufMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                animator.SetBool("Talk", false);
                animator.SetBool("Walk", true);
                player.enabled = true;
                spline.enabled = true;
            }
        }
    }
}
