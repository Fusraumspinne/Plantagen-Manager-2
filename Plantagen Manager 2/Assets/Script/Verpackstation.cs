using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verpackstation : MonoBehaviour
{
    [SerializeField] private int kokainBündel;
    [SerializeField] private GameObject kokainBox;
    [SerializeField] private GameObject spawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bündel") || (other.CompareTag("BündelAbholbar")))
        {
            Destroy(other.gameObject);
            kokainBündel++;
        }
    }

    public void Update()
    {
        if(kokainBündel >= 5) 
        {
            kokainBündel -= 5;

            GameObject spawnedObject = Instantiate(kokainBox, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }
}
