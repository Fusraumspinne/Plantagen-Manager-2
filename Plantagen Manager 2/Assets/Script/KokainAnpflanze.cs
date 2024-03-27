using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KokainAnpflanze : MonoBehaviour
{
    [SerializeField] private Animator[] kokainpflanzeAnimator;
    [SerializeField] private GameObject[] kokainPflanzeObject;
    [SerializeField] private GameObject ausgewachsenePflanze;
    [SerializeField] private GameObject e;
    [SerializeField] private bool active = false;
    [SerializeField] private bool ernten = false;
    [SerializeField] private bool wachsen = false;
    [SerializeField] private bool clear = true;

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject kokainBündel;

    [SerializeField] private string tagTrigger;
    [SerializeField] private bool schwarzlicht;

    [SerializeField] private float cooldownTime;
    private float lastTriggerTime;

    public void Anpflanzen()
    {
        foreach (Animator animator in kokainpflanzeAnimator)
        {
            animator.SetTrigger("wachsen");
        }

        foreach (GameObject gameobject in kokainPflanzeObject)
        {
            gameobject.SetActive(true);
        }

        lastTriggerTime = Time.time;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = true;

            if (!wachsen || ernten)
            {
                e.SetActive(true);
            }
        }

        if (other.CompareTag("Angestellter"))
        {
            Angestellter();
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
            if (active && !ernten && !wachsen)
            {
                Anpflanzen();
                wachsen = true;
                clear = false;

                e.SetActive(false);
            }
            else
            {
                if (ernten && active)
                {
                    ausgewachsenePflanze.SetActive(false);
                    ernten = false;
                    clear = true;

                    GameObject spawnedObject = Instantiate(kokainBündel, spawnPoint.transform);
                    spawnedObject.transform.localPosition = Vector3.zero;
                }
            }
        }

        if (Time.time > lastTriggerTime + cooldownTime)
        {
            if (!clear)
            {
                ernten = true;
                wachsen = false;

                ausgewachsenePflanze.SetActive(true);

                foreach (GameObject gameobject in kokainPflanzeObject)
                {
                    gameobject.SetActive(false);
                }
            }
        }

        GameObject[] schwarzLichtTriggerObjects = GameObject.FindGameObjectsWithTag(tagTrigger);

        foreach (GameObject schwarzLichtTriggerObject in schwarzLichtTriggerObjects)
        {
            Destroy(schwarzLichtTriggerObject);

            if (!schwarzlicht)
            {
                cooldownTime /= 2;

                foreach (Animator animator in kokainpflanzeAnimator)
                {
                    animator.speed = 2f;
                }
            }

            schwarzlicht = true;
        }
    }

    public void Angestellter()
    {
        if (!ernten && !wachsen)
        {
            Anpflanzen();
            wachsen = true;
            clear = false;
        }
        else
        {
            if (ernten)
            {
                ausgewachsenePflanze.SetActive(false);
                ernten = false;
                clear = true;

                GameObject spawnedObject = Instantiate(kokainBündel, spawnPoint.transform);
                spawnedObject.transform.localPosition = Vector3.zero;
            }
        }
    }
}
