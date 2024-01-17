using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;

    [SerializeField] private Transform target;
    [SerializeField] private float zoomFactor = 3.0f; // Increase this value for a closer view
    private Vector3 velocity = Vector3.zero;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Adjust camera's orthographic size for zooming
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 5f / zoomFactor, Time.deltaTime);
    }
}
