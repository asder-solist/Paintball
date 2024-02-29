using UnityEngine;

public class Magnet : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.AddComponent<FixedJoint>();
            other.GetComponent<FixedJoint>().connectedBody = rb;
            StartCoroutine(other.gameObject.GetComponent<Ball>().MagnetPush());
        }
    }

    
}
