using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.rotation * Vector3.forward,
        mainCamera.rotation * Vector3.up);
    }
}
