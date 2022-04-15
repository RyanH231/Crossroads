using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Player player;
    public int pixelDistToDetect = 20;
    public bool onComputer;

    private Vector2 startPos;
    private bool fingerDown;

    private void Update()
    {
        if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && onComputer != true)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if(fingerDown == true)
        {
            if(Input.touches[0].position.y > startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.up);
                Debug.Log("Swiped Up");
            }
            if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                Debug.Log("Swiped Up");
            }
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.left);
                Debug.Log("Swiped left");
            }
            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.right);
                Debug.Log("Swiped right");
            }
        }


        if(onComputer == true && Input.GetKey(KeyCode.Mouse0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
            if(Input.mousePosition.y > startPos.y + pixelDistToDetect && fingerDown == true)
            {
                fingerDown = false;
                player.Move(Vector3.up);
                Debug.Log("Mouse moved up");
            }
            else if (Input.mousePosition.y < startPos.y  - pixelDistToDetect && fingerDown == true)
            {
                fingerDown = false;
                Debug.Log("Mouse moved down");
            }
            else if (Input.mousePosition.x <= startPos.x - pixelDistToDetect && fingerDown == true)
            {
                fingerDown = false;
                player.Move(Vector3.left);
                Debug.Log("Mouse moved left");
            }
            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect && fingerDown == true)
            {
                fingerDown = false;
                player.Move(Vector3.right);
                Debug.Log("Mouse moved right");
            }

            
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}
