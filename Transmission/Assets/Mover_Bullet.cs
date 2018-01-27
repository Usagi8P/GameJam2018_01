using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Bullet : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private Vector3 direction;
    public GameObject source;

    public void Start()
    {
        direction = GameObject.Find("Cube").GetComponent<CharacterScript>().tempDirection;
    }

	// Use this for initialization
	public void Update()
    {
        transform.Translate(direction);

    }
}
