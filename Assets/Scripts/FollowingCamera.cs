using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour {

    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null)
        {
            var pos = Vector3.Lerp(transform.position, Target.transform.position, 1f-Mathf.Pow(0.1f, Time.deltaTime));
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }
	}
}
