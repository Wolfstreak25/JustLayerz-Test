using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    [SerializeField] private LayerMask mask;
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if(hit.collider != null )
                {
                    if(!hit.collider.CompareTag("Drag"))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }

            }
            
        }
        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = worldPosition;
            if(Input.GetMouseButtonDown(1))
            {
                RaycastHit hit = CastRay();
                if(hit.collider.CompareTag("MainBody"))
                {
                    Debug.Log("Hit");
                    selectedObject.transform.position = hit.point;
                }
                else
                {
                    selectedObject.transform.position = worldPosition;
                }
                selectedObject = null;
                Cursor.visible = true;
            }
        }
    }
    RaycastHit CastRay()
    {
        RaycastHit hit;
        Vector3 m_screenMousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 m_screenMousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(m_screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(m_screenMousePosNear);
        Physics.Raycast(worldMousePosNear,worldMousePosFar-worldMousePosNear,out hit);
        return hit;
    }
}
