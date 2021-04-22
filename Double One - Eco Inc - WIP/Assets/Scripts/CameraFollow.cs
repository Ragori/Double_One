using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float speed;

    private Vector3 dragOrigin;

    public bool cameraDrag = true;

    public float outerLeft = 5f;
    public float outerRight = 6f;
    public float outerTop = 5f;
    public float outerBottom = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosision = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);
        float top = Screen.height * 0.2f;
        float bottom = Screen.height - (Screen.height * 0.2f);

        if (mousePosision.x < left)
        {
            cameraDrag = true;
        }
        else if (mousePosision.x > right)
        {
            cameraDrag = true;
        }
        

        dragOrigin = transform.TransformDirection(dragOrigin);

        if (cameraDrag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * speed, pos.y * speed, 0);

            if (move.x > 0f)
            {
                if (this.transform.position.x < outerRight)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.x > outerLeft)
                {
                    transform.Translate(move, Space.World);
                }
            }
            
        }
    }
}
