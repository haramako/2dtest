using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator anim;

	// Use this for initialization
	void Start () {
	
	}

    enum State
    {
        Ground,
        Jumping
    }

    State state;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-10, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(10, 0));
        }

        switch (state) {
            case State.Ground:
                anim.SetBool("Fall", false);
                if (!rb.IsTouchingLayers())
                {
                    anim.SetBool("Fall", true);
                    state = State.Jumping;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector2(0, 300));
                    anim.SetTrigger("IsJump");
                    anim.SetBool("Fall", true);
                    state = State.Jumping;
                }
                break;
            case State.Jumping:
                if( rb.IsTouchingLayers() )
                {
                    anim.SetBool("Fall", false);
                    state = State.Ground;
                }
                break;
        }

        anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("VelocityY", Mathf.Abs(rb.velocity.y));
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) > 5)
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), rb.velocity.y);
        }
    }
}
