using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody rb;

    private Vector3 moveInput; //storing the input from user in a vector
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public RifleScript rifle;

    public bool useController;

    public bool doubleDamageActive;

    public DoubleDamageTimer reference; //this is the reference to the spawn point of double damage pick up
    public int enemiesNumber;
    public bool allEnemiesDead;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>(); //Referencing the only camera in the game
        enemiesNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));  /* Assigning movement values to our moveInput.
                                                                                                       Note : Using GetAxisRaw here so that the movement stops the moment input button is released*/

        moveVelocity = moveInput * moveSpeed;  //For some reason, diagonal movement is faster than unidirectional movement (could be because of two inputs being applied) need to investigate further                                        


        if (useController==false) //This section of code is to be used if the player wants to use the mouse.
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);                   //Shooting a ray from the camera to wherever the mouse is on screen
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);                           //Creating a plane facing up at origin
            float rayLength;                                                                  //This variable is to score the rayLength

            if (groundPlane.Raycast(cameraRay, out rayLength))                             /*This is basically checking if the ray that has been cast is touching the
                                                                                            ground and then it stores the value of the length in rayLength*/
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);                      //Setting a point to look at exactly rayLength units away from the camera
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));//Making the player character look at the point by only rotating the player along y axis
            }

            if (Input.GetMouseButtonDown(0)) //0 for the left click, 1 for right click, 2 for the scroll click

                rifle.isFiring = true;

            if (Input.GetMouseButtonUp(0))
            {

                rifle.isFiring = false;
            }
        }

        if (useController == true)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical"); //Multiplying and adding the vector values to our defined Axes in the InputManager
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection,Vector3.up);//Rotate the player in playerDirection and defines the up direction as default up
                rifle.isFiring = true;//Firing the weapon using right analog stick
            }
            if(playerDirection.sqrMagnitude == 0.0f)
            {
                rifle.isFiring = false; //Stop the firing as soon as the right analog is released (magnitude = 0)
            }
            
            /*if (Input.GetKeyDown(KeyCode.Joystick1Button5)) //This can be used if the player wants to shoot with the Right bumper of the controller
            {
                rifle.isFiring = true;
            }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                rifle.isFiring = false;
            }*/   
        }

        if (doubleDamageActive == true) // counting down the timer so that the double damage expires after 'doubleDamageTime'
        {
            reference.doubleDamageTime -= Time.deltaTime;
            if (reference.doubleDamageTime <= 0)
            {
                doubleDamageActive = false;
                rifle.currentRifleDamage = rifle.rifleDamage; //reverting the damage back to normal
            }
        }

        if (enemiesNumber<=0) 
        {
            allEnemiesDead = true; //setting boolean value true so that the animation can be triggered
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;  /*As a normal update function is dependent only on the screen's frames and independent of the 
                                       physics itself. Hence, fixed update is used so that this value is in synchronization with the physics and the engine
                                       This also smoothens out the movement*/
    }
}