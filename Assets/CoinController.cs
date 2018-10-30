using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject UnityChan;

	// Use this for initialization
	void Start () {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);

        UnityChan = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
        //回転
        this.transform.Rotate(0, 3, 0);

        if(transform.position.z < (UnityChan.transform.position.z - 5)) {
            Destroy(gameObject);
        }
	}
}
