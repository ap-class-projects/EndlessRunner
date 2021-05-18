using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    Animator animator;
    public static GameObject player;
    public static GameObject currentPlatfrom;
    bool canTurn = false;
    Vector3 startPosition;

    private void OnCollisionEnter(Collision other)
    {
        currentPlatfrom = other.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = this.gameObject;
        startPosition = player.transform.position;
        GenerateWorld.runDummy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
        {
            GenerateWorld.runDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is SphereCollider)
        {
            canTurn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("isMagic", true);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(0, 90, 0);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.runDummy();
            player.transform.position = new Vector3(startPosition.x, player.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn )
        {
            this.transform.Rotate(0, -90, 0);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.runDummy();
            player.transform.position = new Vector3(startPosition.x, player.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.4f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.4f, 0, 0);
        }
    }

    void stopJump()
    {
        animator.SetBool("isJumping", false);
    }

    void stopMagic()
    {
        animator.SetBool("isMagic", false);
    }
}
