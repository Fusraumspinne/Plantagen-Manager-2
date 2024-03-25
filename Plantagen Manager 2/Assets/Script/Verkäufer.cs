using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Verkäufer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool active = false;
    [SerializeField] private SplineAnimate splineAnimate;
    [SerializeField] private bool menu = false;
    [SerializeField] private MonoBehaviour triggerPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = false;
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && active)
        {
            menu = true;

            animator.SetBool("walk", false);
            animator.SetBool("idle", false);
            animator.SetBool("talk", true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu = false;

            if (active)
            {
                animator.SetBool("walk", false);
                animator.SetBool("talk", false);
                animator.SetBool("idle", true);
            }
        }

        if (splineAnimate.IsPlaying)
        {
            animator.SetBool("idle", false);
            animator.SetBool("talk", false);
            animator.SetBool("walk", true);

            triggerPanel.enabled = false;
        }
        else
        {
            if (!menu)
            {
                animator.SetBool("walk", false);
                animator.SetBool("talk", false);
                animator.SetBool("idle", true);
            }

            triggerPanel.enabled = true;
        }
    }
}
