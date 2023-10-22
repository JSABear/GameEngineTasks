using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera camera;

    private string groundTag = "Ground";
    
    public GameObject targetdest;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    // Set the agent's destination directly
                    agent.SetDestination(hit.point);
                    targetdest.transform.position = hit.point;
                }
            }
        }
    }
}
