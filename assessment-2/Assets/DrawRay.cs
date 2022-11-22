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
        isDragging = false;
        mainCamera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Debug.Log(isDragging);

        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            Debug.Log(hits.Length);
            Debug.Log("xPos: " + xPos);
            Debug.Log("zPos: " + zPos);
    
            if (hits.Length >=1)
            {
                xPos = hits[quadIndex].point.x;
                zPos = hits[quadIndex].point.z;

                if (hits.Length == 2)
                {
                    Debug.Log(hits[cubeIndex].point);
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
        
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }     
}

