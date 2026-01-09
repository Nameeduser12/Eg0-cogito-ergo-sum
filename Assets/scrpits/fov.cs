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

        }
    }
}
