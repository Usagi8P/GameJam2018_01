using System.Collections;
using UnityEngine;

public class PlayerGridController : PlayerController {

    public byte gridSize = 48;
    bool moving;

    protected override void Movement()
    {
        // Movement
        if (Input.GetButtonDown("Right"))
        {
            StartCoroutine(Move(Vector3.right));
        }
        else if (Input.GetButtonDown("Left"))
        {
            StartCoroutine(Move(Vector3.left));
        }
        else if (Input.GetButtonDown("Down"))
        {
            StartCoroutine(Move(Vector3.back));
        }
        else if (Input.GetButtonDown("Up"))
        {
            StartCoroutine(Move(Vector3.forward));
        }
    }

    IEnumerator Move(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction * (gridSize * 0.01f);
        while (Vector3.Distance(transform.position, newPosition) > 0.1f)
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
            yield return null;
        }
    }
}
