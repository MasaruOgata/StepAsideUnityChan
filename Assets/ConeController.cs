using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour {

    public GameObject UnityChan;

	// Use this for initialization
	void Start () {
        UnityChan = GameObject.Find("unitychan");
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < (UnityChan.transform.position.z - 5))
        {
            Destroy(gameObject);
        }
    }
}

