using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

/*The main script that governs the players movement, saved data and animation. Initially named
 PlayerMovement, this script evolved to be one of the core components to the project. It also 
implements the DPI, meaning it is recognisd as a DPI object and the interface's methods acn be implemented
from other scripts (see DataPersistanceManager script). */
public class PlayerMovement : MonoBehaviour, DPI
{
    public Rigidbody2D rbDD;

    public int speed;
    private float horizontalInput;
    public Animator animator;
    private bool facingRight;

    private bool isJumpPressed;
    private int jumpPower;
    private bool isGrounded;
    public Vector2 speedVector = new Vector2(100, 50);
    private Vector3 movement;

    private AudioSource jumpSound;

    public int playerLevel;
    public List<string> levelTimes;
    public float levelTimer;
     

    public Scene scene;

    

    
    /*Values are initialised, including a jump sound and the current scene, which is
     then given to the playerLevel int as a build index value.*/
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        playerLevel = scene.buildIndex;
        Debug.Log("Player Level" + playerLevel);
    }

    /*The player's animator is accounted for here, with the horizontal input and speed
     variables being taken into account. In addition the space key's input is detected and
    acted upon in the FixedUpdate method. */
    void Update()
    {
        animator.SetFloat("HorizontalInput", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        levelTimer += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space)) {

            isJumpPressed = true;
            
        }

        levelTimer += Time.deltaTime;
    }

    /*The FixedUpate method is called to register the player's horizontal movement
     and also to flip the player the correct way using the flipPlayer method for animation
    purposes. In addition, the jump action is implemented based on the bools isJumpPressed
    and isGrounded.*/
    private void FixedUpdate()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        speed = 20;
        
        movement = new Vector3(horizontalInput * speed, rbDD.velocity.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (horizontalInput > 0 && facingRight)
        {
            flipPlayer();
        }

        if (horizontalInput < 0 && !facingRight)
        {
            flipPlayer();
        }

        //Jump ability.
        jumpPower = 20;
        if (isJumpPressed&&isGrounded)        {
            rbDD.velocity = Vector2.up * jumpPower;
            isJumpPressed = false;
            isGrounded = false;
            jumpSound.Play();
        }

        
    }

    /*A method to check the player's grounded status.The player can only jump if they
    are in contact with the level (so cannot jump in the air)*/
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Level")) {
            isGrounded = true;

        }
    }

    /*This method changes the scale of the player so that it faces the correct way when animated.*/
    private void flipPlayer() {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *=-1;
        gameObject.transform.localScale = scale;

        facingRight = !facingRight; 


    
    
    }

    /*This method uses the LoadGameData method implemented by the DPI, and sets the current
     gamedata values to those found in the data.*/
    public void LoadGameData(GameData data) {

        this.playerLevel = data.currentLevel;
        this.levelTimes = data.timeOnLevel;
        Assessment.levelTimes = data.timeOnLevel;

    }

    /**This SaveGameData method takes the duration of play (measured using a float and Time.Delta)
    and converts it to a string, which is then added directly to the Gamedata object. It also
    saves the player's current level using scene.build index, meaning that the player can
    load the scene in which they were previously playing.**/ 
    public void SaveGameData(GameData data) {

        string levelTime = levelTimer.ToString("0.00");
        data.currentLevel = scene.buildIndex;

        if (data.timeOnLevel.Count < scene.buildIndex)
        {
            data.timeOnLevel.Add(levelTime);
        }

       
        else if (data.timeOnLevel.Count == scene.buildIndex) {
            float lastTime = float.Parse(data.timeOnLevel[data.timeOnLevel.Count-1],
                CultureInfo.InvariantCulture.NumberFormat);
            lastTime += levelTimer;
            data.timeOnLevel.RemoveAt(data.timeOnLevel.Count-1);
            data.timeOnLevel.Insert(data.timeOnLevel.Count, lastTime.ToString());
            Debug.Log("scene index" + scene.buildIndex);
        
        }
         

        
        
    }


    /*<!--Number Planet - PlayerMovement
@Author: Julian Laffin -->*/



}
