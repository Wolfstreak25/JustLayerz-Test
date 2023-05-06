using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform m_toLookAt;
    [SerializeField] private float m_moveSpeed;
    void Update()
    {
        transform.LookAt(m_toLookAt, Vector3.up);
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Vector3.forward *  m_moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.back *  m_moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left *  m_moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right *  m_moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + Vector3.up *  m_moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = transform.position + Vector3.down *  m_moveSpeed * Time.deltaTime;
        }
    }
}
