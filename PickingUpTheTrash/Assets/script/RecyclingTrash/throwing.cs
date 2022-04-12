using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwing : MonoBehaviour
{
    public GameObject ball;
    public GameObject mainCamera;
    private Rigidbody ball_rb;

    public float throwDistance = 20f;
    public float throwForce = 5f;
    public Vector3 direction;

    private bool holding = true;

    private float pressed_pos_x;
    private float pressed_pos_z;

    void Start()
    {
        ball_rb = ball.GetComponent<Rigidbody>();
        ball_rb.useGravity = false;
       
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (holding)
        {
            ball.transform.position = mainCamera.transform.position + mainCamera.transform.forward * throwDistance;

            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.gameObject == ball)
                {
                    holding = false;
                    store_position();
                    Debug.Log("mouse pressed");
                }
                
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBall(Input.mousePosition);
            Debug.Log("mouse up");
        }
    }

    private void store_position()
    {
        pressed_pos_x = Input.mousePosition.x;
        pressed_pos_z = Input.mousePosition.y;
        Debug.Log("pressed_pos_x : " + pressed_pos_x);
        Debug.Log("pressed_pos_y : " + pressed_pos_z);
    }

    private void ThrowBall(Vector3 mousePos)
    {
        ball_rb.useGravity = true;

        float differencex = Mathf.Clamp(mousePos.x - pressed_pos_x, 0f, 10f);
        float differencez = Mathf.Clamp(mousePos.z - pressed_pos_z, 0f, 10f);
        direction = new Vector3(differencex, 0, differencez);

        ball_rb.AddForce(direction * throwForce);
    }
}
