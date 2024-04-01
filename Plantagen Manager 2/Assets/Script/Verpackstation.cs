using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verpackstation : MonoBehaviour
{
    [SerializeField] private int b�ndel;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private string objectTag1;
    [SerializeField] private string objectTag2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag1) || other.CompareTag(objectTag2))
        {
            Destroy(other.gameObject);
            b�ndel++;
        }
    }

    public void Update()
    {
        if(b�ndel >= 5) 
        {
            b�ndel -= 5;

            GameObject spawnedObject = Instantiate(box, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }
}
