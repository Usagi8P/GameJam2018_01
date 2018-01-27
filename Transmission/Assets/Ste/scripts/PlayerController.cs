using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    public float timeUntilNextSwitch = 1;
    public GameObject effect;
    public GameObject signal;
    public enum State { Alive, GameOver};
    public static State state;
    Vector3 direction;
    Transform enemy;
    GameMaster gm;
    GameObject signalInstance;
    bool canSwitch, stopSwitch;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    void FixedUpdate () {
        if (state == State.GameOver) return;

        // Movement
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
        }

        // Change of body
        if (canSwitch && !stopSwitch && Input.GetButtonDown("Submit")) {
            Vector3 newPosition = transform.position;

            gm.RechargeBar();
            Instantiate(effect, transform.position, RotateTowards(enemy));
            transform.position = enemy.transform.position;

            enemy.transform.position = newPosition;
            StartCoroutine(WaitTime(timeUntilNextSwitch));
        }
	}

    Quaternion RotateTowards(Transform point)
    {
        Vector3 direction = (point.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        return Quaternion.Slerp(enemy.rotation, lookRotation, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<EnemyController>() && !stopSwitch)
        {
            if (signalInstance == null)
                signalInstance = Instantiate(signal, transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() && !stopSwitch)
        {
            enemy = other.transform;
            canSwitch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyController>())
        {
            Destroy(signalInstance);
            canSwitch = false;
        }
    }

    IEnumerator WaitTime(float seconds)
    {
        stopSwitch = true;
        Destroy(signalInstance);
        yield return new WaitForSeconds(seconds);
        stopSwitch = false;
    }
}