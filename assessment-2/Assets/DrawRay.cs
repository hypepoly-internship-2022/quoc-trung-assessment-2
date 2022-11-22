using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    Camera mainCamera;
    Vector3 mousePos;
    
    void Start()
    {
       
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit hit;
        mousePos = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.tag == "Object" && Input.GetMouseButton(0))
            {  
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                hit.transform.position = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);    
            }
        }
    }
}
