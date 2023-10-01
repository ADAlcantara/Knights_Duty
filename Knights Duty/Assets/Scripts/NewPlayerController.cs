using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    //public float dashSpeed;
    //public float dashTime;
    CharacterController playerController;
    Animator charAnim;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        charAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    StartCoroutine(Dash());
        //    charAnim.SetBool("Dash", true);
        //}
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        //=========== Input for Movement ===========
        float FBinput = Input.GetAxisRaw("Horizontal");
        float LRinput = Input.GetAxisRaw("Vertical");
        //============================================

        Vector3 movementDirection = new Vector3(FBinput, 0, LRinput); //converts input into movement
        movementDirection = Quaternion.Euler(0, 45f, 0) * movementDirection; //rotates by 45° on y axis
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed; 
        movementDirection.Normalize(); //normalizes movement

        playerController.SimpleMove(movementDirection * magnitude); //script for movement

        if (movementDirection != Vector3.zero) //movement in relation to isometric camera
        {
            charAnim.SetBool("Run", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
        else
        {
            charAnim.SetBool("Run", false);
        }
    }
    //IEnumerator Dash()
    //{
    //    float startTime = Time.time;
    //    float FBinput = Input.GetAxisRaw("Horizontal");
    //    float LRinput = Input.GetAxisRaw("Vertical");
    //    //============================================

    //    Vector3 movementDirection = new Vector3(FBinput, 0, LRinput); //converts input into movement
    //    movementDirection = Quaternion.Euler(0, 45f, 0) * movementDirection; //rotates by 45° on y axis

    //    while (Time.time < startTime + dashTime)
    //    {
    //        playerController.Move(movementDirection * dashSpeed * Time.deltaTime);
    //        charAnim.SetBool("Dash", false);
    //        yield return null;
    //    }
    //}
}