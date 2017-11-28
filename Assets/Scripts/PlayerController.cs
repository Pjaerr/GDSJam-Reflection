using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Transform trans; //Cached reference to this object's transform.
    private Rigidbody rb;
    [SerializeField] private float movementSpeed; //Movement Speed, adjustable in the editor.
    private Animator animator;

    void Start()
    {
        trans = GetComponent<Transform>(); //Stores reference to this object's transform.
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    //Update() is called every frame.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {
        float step = movementSpeed * Time.deltaTime; //Stores movementspeed * deltatime to keep movement non-fps dependant.

        /*Checks for WASD, and increases or decreases x/y by 1, and then translates this player by those amounts
		multiplied by the step created above.*/

        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Walk");
            y += 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Walk");
            y -= 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("Walk");
            x -= 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("Walk");
            x += 1;
        }


        rb.MovePosition(rb.position + new Vector3(x * step, 0, y * step));
    }

    public void KillPlayer()
    {
        trans.position = GameManager.instance.startPos.position;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Door")
        {
            GameManager.instance.nextLevel();
        }
    }


}
