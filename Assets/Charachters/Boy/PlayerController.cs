using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xValue, yValue, zValue;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;

    float horizontalValue, verticalValue;

    Animator animator;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        xValue = 0;
        yValue = 0;
        zValue = 0;

        horizontalSpeed = 2;
        verticalSpeed = 3;

        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        isDead = animator.GetBool("isDead");
        if( !isDead )
        {
            //Movements - start
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");

            if(verticalValue > 0 || horizontalValue != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            //W S
            zValue = verticalValue * Time.deltaTime * verticalSpeed;
            //A D
            xValue = horizontalValue * Time.deltaTime * horizontalSpeed;

            transform.Translate(xValue, yValue, zValue);

            //Jump input
            if(Input.GetAxis("Jump") > 0)
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
            //Movements - end
        }
        else
        {
            animator.SetBool("isDead", true);
        }


    }
}
