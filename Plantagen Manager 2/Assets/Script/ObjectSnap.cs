using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    [SerializeField] private bool active = false;
    [SerializeField] private bool tp = false;
    [SerializeField] private string targetTag = "Drag"; 
    private GameObject targetObject; 
    [SerializeField] private Rigidbody rb;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drag"))
        {
            active = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drag"))
        {
            active = false;
        }
    }

    public void Update()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tp = true;
            }
        }

        if (Input.GetMouseButton(1))
        {
            rb.isKinematic = true;
            tp = false;
            rb.isKinematic = false;
        }

        if (tp)
        {
            TeleportObject();
        }
    }

    private void TeleportObject()
    {
        if (targetObject != null) 
        {
            transform.position = targetObject.transform.position;
        }
    }

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
    }
}
