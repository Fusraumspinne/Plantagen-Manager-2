using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    [SerializeField] private string targetTag; 
    [SerializeField] private NavMeshAgent agent; 
    [SerializeField] private bool finden;
    [SerializeField] private bool aufDemWeg;
    [SerializeField] private bool gefunden;
    [SerializeField] private bool abgegeben;
    [SerializeField] private bool zerstören;

    [SerializeField] private bool lagern;
    [SerializeField] private bool einpacken;
    [SerializeField] private bool verarbeiten;

    [SerializeField] private GameObject bündel;
    [SerializeField] private GameObject deco;
    [SerializeField] private Transform lager;
    [SerializeField] private Transform verpackstation;
    [SerializeField] private Transform labor;
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private GameObject spawnPointLager;
    [SerializeField] private GameObject spawnPointVerpackstation;
    [SerializeField] private GameObject spawnPointLabor;

    [SerializeField] private GameObject greenBtnLager;
    [SerializeField] private GameObject redBtnLager;
    [SerializeField] private GameObject greenBtnVerpacken;
    [SerializeField] private GameObject redBtnVerpacken;
    [SerializeField] private GameObject greenBtnLabor;
    [SerializeField] private GameObject redBtnLabor;

    public void Update()
    {

        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        if(targets.Length > 0)
        {
            finden = true;
        }

        if (abgegeben && finden)
        {
            GameObject closestTarget = null;
            float closestDistance = Mathf.Infinity;
            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }

            if (closestTarget != null)
            {
                agent.SetDestination(closestTarget.transform.position);

                abgegeben = false;
                aufDemWeg = true;
            }
        }
        else if (aufDemWeg)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    aufDemWeg = false;
                    gefunden = true;
                    zerstören = true;

                    trigger.enabled = true;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && gefunden)
        {
            if (zerstören)
            {
                Destroy(other.gameObject);
                zerstören = false;
            }

            deco.SetActive(true);

            if (lagern)
            {
                agent.SetDestination(lager.transform.position);
            }
            else if (einpacken)
            {
                agent.SetDestination(verpackstation.transform.position);
            } 
            else if (verarbeiten)
            {
                agent.SetDestination(labor.transform.position);
            }
            else
            {
                agent.SetDestination(lager.transform.position);
            }
        }
        else if (other.CompareTag("Lager") && gefunden)
        {
            deco.SetActive(false);
            trigger.enabled = false;
            abgegeben = true;

            GameObject spawnedObject = Instantiate(bündel, spawnPointLager.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
        else if (other.CompareTag("Verpackstation") && gefunden)
        {
            deco.SetActive(false);
            trigger.enabled = false;
            abgegeben = true;

            GameObject spawnedObject = Instantiate(bündel, spawnPointVerpackstation.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
        else if (other.CompareTag("Labor") && gefunden)
        {
            deco.SetActive(false);
            trigger.enabled = false;
            abgegeben = true;

            GameObject spawnedObject = Instantiate(bündel, spawnPointLabor.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }

    public void Lagern()
    {
        einpacken = false;
        verarbeiten = false;
        lagern = true;

        greenBtnLager.SetActive(true);
        redBtnVerpacken.SetActive(true);
        redBtnLabor.SetActive(true);
        redBtnLager.SetActive(false);
        greenBtnLabor.SetActive(false);
        greenBtnVerpacken.SetActive(false);
    }

    public void Einpacken()
    {
        lagern = false;
        verarbeiten = false;
        einpacken = true;

        redBtnLager.SetActive(true);
        redBtnLabor.SetActive(true);
        greenBtnVerpacken.SetActive(true);
        greenBtnLager.SetActive(false);
        redBtnVerpacken.SetActive(false);
        greenBtnLabor.SetActive(false);
    }

    public void Verarbeiten()
    {
        lagern = false;
        einpacken = false;
        verarbeiten = true;

        redBtnLager.SetActive(true);
        greenBtnLabor.SetActive(true);
        redBtnVerpacken.SetActive(true);
        redBtnLabor.SetActive(false);
        greenBtnLager.SetActive(false);
        greenBtnVerpacken.SetActive(false);
    }
}
