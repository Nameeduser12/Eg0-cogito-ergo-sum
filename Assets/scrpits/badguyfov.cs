using UnityEngine;
using System.Collections;

public class badguyfov : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // parameters
    public float radius;
    public float angle;
    public GameObject PlayerRef;
    //public GameObject target;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    

    void Start()
    {
        // Start
        PlayerRef = GameObject.FindWithTag("Player");
        StartCoroutine(FOVroutine());

    }

    private IEnumerator FOVroutine()
    {
        //delay check
       WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }

    }

    private void FieldOfViewCheck()
    { // cast ray for position and distance from target
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position).normalized;
        
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                    else
                    canSeePlayer = false;    
            }
            else 
                canSeePlayer = false;
        }
        else if (canSeePlayer)
               canSeePlayer = false;
    }
}