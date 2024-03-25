using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablenManager : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private string objectTag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            Destroy(other.gameObject);

            GameObject spawnedObject = Instantiate(trigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }
}
