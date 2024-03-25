using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlickHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject handy;

    public void OnMouseDown()
    {
        panel.SetActive(true);
        handy.SetActive(false);
    }
}
