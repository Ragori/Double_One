using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public Camera cam;
    public float zoom, minZoom, maxZoom;
    public SpriteRenderer mapRender;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private Vector3 dragOrigin;


    private void Awake()
    {
        mapMinX = mapRender.transform.position.x - mapRender.bounds.size.x / 2f;
        mapMaxX = mapRender.transform.position.x + mapRender.bounds.size.x / 2f;

        mapMinY = mapRender.transform.position.y - mapRender.bounds.size.y / 2f;
        mapMaxY = mapRender.transform.position.y + mapRender.bounds.size.y / 2f;
    }

    private void Update()
    {
        PanCamera();

    }

    private void PanCamera()
    {

        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = CameraClamp(cam.transform.position + difference);
            
        }

    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoom;
        cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);

        cam.transform.position = CameraClamp(cam.transform.position);
    }
    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoom;
        cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);

        cam.transform.position = CameraClamp(cam.transform.position);
    }

    private Vector3 CameraClamp(Vector3 targetPosision)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosision.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosision.y, minY, maxY);

        return new Vector3(newX, newY, targetPosision.z);
    }

}
