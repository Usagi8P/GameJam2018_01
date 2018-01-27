using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    private Transform character;
    private Vector3 direction;

    private void Start()
    {
        this.character = GameObject.FindGameObjectWithTag("Character").transform;
        direction = character.position - transform.position;
        StartCoroutine("WaitToDestroy");
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void FixedUpdate ()
    {
        transform.Translate(direction * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
