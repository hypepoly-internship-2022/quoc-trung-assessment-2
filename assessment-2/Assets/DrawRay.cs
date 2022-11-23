using UnityEngine;

public class DrawRay : MonoBehaviour
{
    Camera mainCamera;
    bool isDragging;
    GameObject cubeObject;
    float xPos;
    float zPos;
    int quadIndex = 0;
    int cubeIndex = 1;
    
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
 
            if (hits.Length >=1)
            {
                xPos = hits[quadIndex].point.x;
                zPos = hits[quadIndex].point.z;

                if (hits.Length == 2)
                {
                    isDragging = true;
                    cubeObject = hits[cubeIndex].collider.gameObject;
                }
            }
            if (isDragging)
            {
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                Vector3 pos = new Vector3(xPos, cubeObject.gameObject.transform.position.y, zPos);
                cubeObject.transform.position = pos;
            }
        }
        else
        {
            isDragging=false;
        }
    } 
}

