using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    bool started = false;

    void Awake()
    {

    }

	void Start () {
        DontDestroyOnLoad(this.gameObject);     
    }

    // Update is called once per frame
    void Update () {
        
    }
}
