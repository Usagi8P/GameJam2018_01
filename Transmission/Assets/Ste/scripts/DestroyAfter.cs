using System.Collections;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    [SerializeField] float destroyAfter = 1f;

	void Start () {
        Destroy(this.gameObject, destroyAfter);
	}
}
