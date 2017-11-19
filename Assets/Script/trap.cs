using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Go ());
	}

	IEnumerator Go(){
		while (true) {
			GetComponent<Animation>().Play();
			yield return new WaitForSeconds(3f);
				}
		}
}
