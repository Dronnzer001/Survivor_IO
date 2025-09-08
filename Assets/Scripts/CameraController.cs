using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spinner;
    public float SpeedMove;
    public Vector3 Offest;
    private Vector3 rb;
    internal bool Manage = true;

    [Header("Camera Bounds")]
    public bool useBounds = true;
    public Vector2 minBounds; // Bottom-left corner
    public Vector2 maxBounds; // Top-right corner
    private Boundries boundries;
    private void Start()
    {
      
    }

    private void SetBounds()
    {
      
    }

    void LateUpdate()
    {
     
        Vector3 targetPos = Player.transform.position + Offest;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref rb, SpeedMove);

        if (useBounds)
        {
            // Clamp X and Y positions, keep Z as is
            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
        SetBounds();
    }

    void Update()
    {
        if (Spinner.activeSelf && Manage)
        {
            Camera cam = GetComponent<Camera>();
            cam.fieldOfView += 0.5f;
            if (cam.fieldOfView >= 85)
            {
                Manage = false;
            }
        }
    }
}
