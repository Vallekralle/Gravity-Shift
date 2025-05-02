using UnityEngine;

public class ForceDependent : MonoBehaviour
{
    [SerializeField] private new string name;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    private void Start()
    {
        startPosition = GetComponent<Transform>().position;
        startRotation = GetComponent<Transform>().rotation;
        rb = GetComponent<Rigidbody>();
    }

    public string getName()
    {
        return name;
    }

    public Rigidbody getRb()
    { 
        return rb; 
    }

    public Vector3 getStartPosition()
    {
        return startPosition;
    }

    public Quaternion getStartRotation()
    {
        return startRotation;
    }

    public Rigidbody getRigidbody()
    { 
        return rb; 
    }
}
