using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour {

    public float detectionRange;

    [Header("Movement Variables")]
    public GameObject pathsRoot;
    public Transform[] paths;
    public float speed;
    public float rotationSpeed;
    Transform character;
    private byte pathIndex;
    private bool alerted;

    [Header("Bullet Variables")]
    public GameObject bullet;
    public float rateOfFire;
    private float rateOfFireStore;

    void Start ()
    {
        if (character == null)
            character = FindObjectOfType<PlayerController>().transform;

        if (paths.Length == 0)
        {
            paths = pathsRoot.GetComponentsInChildren<Transform>();
            paths[0] = transform;
        }

        rateOfFireStore = rateOfFire;
        pathIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Character / Player in range
        if ((character.position - transform.position).magnitude < detectionRange)
        {
            rateOfFire -= Time.deltaTime;
            if (rateOfFire <= 0)
            {
                Shoot();
                rateOfFire = rateOfFireStore;
            }
            MoveToPoint(character);
        }
        else
        {
            //Path Finding
            if ((paths[pathIndex].position - transform.position).magnitude < 0.02f && pathsRoot)
            {
                if (pathIndex == paths.Length - 1)
                {
                    pathIndex = 0;
                }
                else
                    pathIndex++;
            }
            else
            {
                MoveToPoint(paths[pathIndex]);
            }
        }
    }

    void Shoot()
    { 
        GameObject.Instantiate(bullet, (character.position - transform.position).normalized * 3 + transform.position, Quaternion.identity);
    }

    void RotateTowards(Transform point)
    {
        Vector3 direction = (point.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed);
    }

    void MoveToPoint(Transform point)
    {
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.fixedDeltaTime);
    }
    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        for(int i = 0; i < paths.Length; i++)
        {
            Gizmos.DrawSphere(paths[i].position, 1);
        }
    }*/
}