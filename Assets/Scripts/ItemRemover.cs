using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour {

	private GameObject Unitychan;
	
	void Start(){
		Unitychan = GameObject.FindWithTag("Unitychan");
	}

	// Update is called once per frame
	void Update () {
		//UnityちゃんのZ座標-10の位置以下にきた時Destroyする
		if(this.gameObject.transform.position.z < Unitychan.transform.position.z - 10){
			Destroy(this.gameObject);
		}
	}
}
