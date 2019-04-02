using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float damage;
    public float range;
    public Camera playerCamera;
    protected float cameraAngle;
    protected float cameraAngleSpeed=0.2f;
    public FixedTouchField touchField;
    public FixedJoystick leftJoystick;
    Vector2 touchDeltaPosition;
    private Vector3 m_move;
    public Enemy enemyScript;
    public float hMovement;
    public float vMovement;

    private void Start()
    {

    }

    void Update()
    {
        MovePlayer();
        MoveCameraPlayer();
    }


    private void OnMouseDown()
    {
        Shoot();
        
    }

    private void FixedUpdate()
    {
        
    }

    void MovePlayer()
    {
        hMovement = leftJoystick.Horizontal;
        vMovement = leftJoystick.Vertical;

        m_move = hMovement * Vector3.right + vMovement * Vector3.forward;
    }

    void MoveCameraPlayer()
    {
        cameraAngle += touchField.TouchDist.x * cameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngle, Vector3.up) * new Vector3(-50, 19 , 10);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up*2f - Camera.main.transform.position, Vector3.up);
        

    }


    void Shoot()
    {
        RaycastHit hit;
        Ray ray;
        if(Input.touchCount>0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if(Physics.Raycast(ray,out hit , Mathf.Infinity))
            {
                enemyScript.TakeDamage(damage);
            }
        }

    }
    
}