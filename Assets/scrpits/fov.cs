using UnityEngine;


public class fov
{
    public float radius;
    public float angle;

    public GameObject PlayerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;




    private void Start()
    {
        PlayerRef = GameObject.findGameObjectWithTag("Player");
        Startcoroutine(FOVroutine());

    }


    private IEnumerator FOVroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();

        }

    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverLapSphere(transform.position, raidius, targetMask);

        if(rangeChecks.Length != 0)
        {
            transform target = rangeChecks[0].transform;
            //Vector3 directionToTarget (target.position).normalized;
            

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = vector3.Distance(transform.position, tagret.position);

                if(!Physics.raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
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
