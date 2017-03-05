using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AnimationPhysics : MonoBehaviour {

    Vector3 oldPos;

    void FixedUpdate()
    {
        var pos = transform.position;
        var v = (pos - oldPos) / Time.deltaTime;
        var rg = GetComponent<Rigidbody2D>();
        rg.velocity = v/4;
        oldPos = pos;
    }
}
