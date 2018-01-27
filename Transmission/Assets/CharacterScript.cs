using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    public Camera camera;
    private float nextFire;
    private RaycastHit hit;
    public Vector3 tempDirection;

	// Update is called once per frame
	void Update ()
    {
        hit = new RaycastHit();
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);       
            if (Physics.Raycast(ray, out hit))
            {
                tempDirection = (hit.point - gameObject.transform.position).normalized;
                nextFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            }
        }
    }
}
