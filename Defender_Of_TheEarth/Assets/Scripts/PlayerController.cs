using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float range;
    public Camera playerCamera;
    Vector2 touchDeltaPosition;

    void Update()
    {
        MoveCameraPlayer();
    }

    void MoveCameraPlayer()
    {
        /*funciona en pc , hace que se traslade la camara al lugar que estas moviendo*/

        if (Input.GetMouseButton(0))
        {
            float pointer_x = Input.GetAxis("Mouse X");
            float pointer_y = Input.GetAxis("Mouse Y");
            playerCamera.transform.Translate(-pointer_x * 0.5f,
                        -pointer_y * 0.5f, 0);
        }

        /*Funciona en mobile , hace que se traslade la camara con el movimiento que le haces*/
        /*  if (Input.touchCount == 1)
         {
             Touch touchZero = Input.GetTouch(0);
             if (touchZero.phase == TouchPhase.Moved)
             {
                 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                 transform.eulerAngles += new Vector3(touchDeltaPosition.y, -touchDeltaPosition.x, 0);﻿
             }
         }
         */
    }

    void Shoot()
    {
        RaycastHit hit;
        //si por fisicas con raycasting, toma algo desde el origen con la direccion forward,con un rango maximo
        if(Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward, out hit , range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}