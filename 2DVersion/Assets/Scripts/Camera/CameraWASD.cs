using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWASD : MonoBehaviour
{

    public float panSpeed = 20f;
    public float scrollSpeed = 20f;
    public float panBorder = 5f;
    public Vector2 panLimit;
    public Vector2 mapLimit;
    public float zoomOutLimit = 15f;
    public float zoomInLimit = 0.5f;

    private Vector3 currentPosition;
    private float currentZoom;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        currentZoom = Camera.main.orthographicSize;


        // Update camera zoom
        float zoomValueToAdd = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100f * Time.deltaTime;
        if (CheckIfNewZoomDoesntBreakZoomRules(zoomValueToAdd))
        {
            Camera.main.orthographicSize -= zoomValueToAdd;
        }


        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            currentPosition.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            currentPosition.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.height - panBorder)
        {
            currentPosition.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.y <= -panBorder)
        {
            currentPosition.x -= panSpeed * Time.deltaTime;
        }

        currentPosition.x = Mathf.Clamp(currentPosition.x, -panLimit.x, panLimit.x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -panLimit.x, panLimit.y);

        transform.position = currentPosition;




    }


    public bool CheckIfNewZoomDoesntBreakZoomRules(float zoomToAdd)
    {
        return ((currentZoom - zoomToAdd >= zoomInLimit) && (currentZoom - zoomToAdd <= zoomOutLimit));
    }


}
