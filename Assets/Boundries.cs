using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
  
   private CinemachineConfiner2D confiner;
    private void OnEnable()
    {
     
        confiner = GameObject.FindGameObjectWithTag("VirtualCam").GetComponent<CinemachineConfiner2D>();
        confiner.m_BoundingShape2D = GetComponent<PolygonCollider2D>();
    }
}
