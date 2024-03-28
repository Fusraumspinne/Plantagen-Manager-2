using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verpackstation : MonoBehaviour
{
    [SerializeField] private int kokainB�ndel;
    [SerializeField] private GameObject kokainBox;
    [SerializeField] private GameObject spawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("B�ndel") || (other.CompareTag("B�ndelAbholbar")))
        {
            Destroy(other.gameObject);
            kokainB�ndel++;
        }
    }

    public void Update()
    {
        if(kokainB�ndel >= 5) 
        {
            kokainB�ndel -= 5;

            GameObject spawnedObject = Instantiate(kokainBox, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }
}
