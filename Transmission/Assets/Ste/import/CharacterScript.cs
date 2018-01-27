using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public float speed;


	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0 ,
            Input.GetAxis("Vertical") * speed);

        transform.Translate(velocity);
	}
}
