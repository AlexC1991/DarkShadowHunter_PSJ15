using System;
using UnityEngine;
public class ShadowMasterScript : MonoBehaviour
{
    [SerializeField] private float visionRadius = 1;
    [SerializeField] private GameObject player;
    private Vector3 playerCoordinates;

    private void Update()
    {
        if (PlayerIsClose())
        {
            transform.LookAt(player.transform.position);
        }
    }
    
    
    private bool PlayerIsClose()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < visionRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
