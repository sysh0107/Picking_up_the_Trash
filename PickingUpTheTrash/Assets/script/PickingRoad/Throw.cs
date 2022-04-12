using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public AudioSource audio1; // when thouch the trahs -> sound play ~
    public LayerMask trash;
    GameObject currenthit;

    void Update()
    {
        //raycasting
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;


            //        Touch touch = Input.GetTouch(0);
            Debug.Log(Input.GetTouch(0));

            // Halve the size of the cube.

            // when cat hit
            if (Input.touches[0].phase == TouchPhase.Began &&
                   Physics.Raycast(ray, out hit, Mathf.Infinity, trash))
            {
                //   hit.collider.attachedRigidbody.AddForce(ray.direction * 100f);
                if (hit.collider.CompareTag("normal"))
                {
                    // if trash is normaltrash like gum
                    // Just destroy
                    // Normal trash collect +1

                    currenthit = hit.collider.gameObject;
                    Destroy(currenthit);
                    Debug.Log("Good by gum ~");
                    audio1.Play();
                }else 
                {
                    // if trahs is not normal
                    // Let's move on the next scene.
                    // In the next scene, start recycling
                    SceneManager.LoadScene("recycle");
                }

            }

         //   transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
        }
    }
}
