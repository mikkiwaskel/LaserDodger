using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

[RequireComponent (typeof (LineRenderer))]
public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float laserDistance = 200f;
    [SerializeField] private float laserHieght = 3f;
    [SerializeField] private LayerMask ignoreMask;

    private RaycastHit rayHit;
    private Ray ray;

    public AudioClip shotClip;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
    }

    void FixedUpdate()
    {
        ray = new(transform.position, transform.forward);
        

        if (Physics.Raycast(ray, out rayHit, laserDistance, ~ignoreMask))
        {

            
            if(rayHit.collider)
            {
                Sounds_Manager.instance.SFX(shotClip);
                lineRenderer.SetPosition(1, new Vector3(0, 0, rayHit.distance));
                if(rayHit.collider.gameObject.tag == "Player")
                {
                    GameManager.instance.isDead = true;
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, laserDistance));
        }
        
    }

    
}
