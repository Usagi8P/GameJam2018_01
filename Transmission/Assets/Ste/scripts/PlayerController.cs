using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Tooltip("The speed movement.")] public float speed = 2;
    [Tooltip("The time to wait for the next switch of body.")] public float waitTime = 1;
    public static bool gameOver;
    Vector3 direction;
    Transform enemy;
    GameObject signalInstance;
    Animator anim;
    bool canSwitch;
    static bool stopSwitch;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate () {
        if (gameOver)
        {
            if (signalInstance) Destroy(signalInstance);
            //return;
        }

        Movement();

        // Change of body
        if (canSwitch && !stopSwitch && Input.GetButtonDown("Submit")) {
            ChangeBody();
        }
	}

    protected virtual void Movement()
    {
        // Movement
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);

        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.z);
        if (velocity != Vector3.zero)
        {
            anim.SetBool("walk", true);
            transform.Translate(velocity);
        }
        else
            anim.SetBool("walk", false);
    }

    void ChangeBody()
    {
        //GameMaster.instance.RechargeBar();
        Instantiate(GameMaster.objEffect, transform.position, RotateTowards(enemy));

        enemy.GetComponent<NPCBehaviour>().enabled = false;
        this.GetComponent<NPCBehaviour>().enabled = true;
        this.enabled = false;
        enemy.GetComponent<PlayerController>().enabled = true;

        StartCoroutine(WaitTime(waitTime));
    }

    Quaternion RotateTowards(Transform point)
    {
        Vector3 direction = (point.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        return Quaternion.Slerp(enemy.rotation, lookRotation, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<NPCBehaviour>() && GetComponent<PlayerController>().isActiveAndEnabled && !stopSwitch)
        {
            if (signalInstance == null)
                signalInstance = Instantiate(GameMaster.objSignal, transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NPCBehaviour>() && !stopSwitch)
        {
            enemy = other.transform;
            canSwitch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NPCBehaviour>())
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