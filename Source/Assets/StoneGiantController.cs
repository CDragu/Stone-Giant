using UnityEngine;
using System.Collections;

public class StoneGiantController : MonoBehaviour {

    public Animator anim;

    public new Rigidbody rigidbody;

    public float walkspeed = 1, turnspeed=1;

    private float inputH, inputV;
    private bool interact,Walk,Idle;
    public bool crouch;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            Walk = true;
            this.rigidbody.velocity = this.transform.forward * walkspeed;
        }
        else
        {
            Walk = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rigidbody.AddTorque(-transform.right * turnspeed);
            transform.Rotate(new Vector3(0, -turnspeed, 0), 1);
            //this.rigidbody.rotation = new Quaternion(this.rigidbody.rotation.x, this.rigidbody.rotation.y+turnspeed, this.rigidbody.rotation.z, this.rigidbody.rotation.w);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, turnspeed, 0), 1);
            // rigidbody.AddTorque(transform.right * turnspeed);
            //this.rigidbody.rotation = new Quaternion(this.rigidbody.rotation.x, this.rigidbody.rotation.y - turnspeed, this.rigidbody.rotation.z, this.rigidbody.rotation.w);

        }
        if (Input.GetKey(KeyCode.S))
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetBool("Walk", Walk);
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetBool("Crouch", crouch);




	}
}
