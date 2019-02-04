using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetAllText();

        score = 0;
        SetAllText();

        lives = 3;
        SetAllText();

        winText.text = "";

    }

    private void Update() {

        if (Input.GetKey("escape")) {

            Application.Quit();

        }

    }


    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }


    // Destroy everything that enters the trigger

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up")) {

            other.gameObject.SetActive(false);
            count = count + 1;

            // Tier 2: adds 1 to the score if player touches the pickups
            score = score + 1;
            SetAllText();

        }

        else if (other.gameObject.CompareTag("Enemy")) {

            other.gameObject.SetActive(false);
            count = count + 1;

            // Tier 2: removes 1 from the score if player touches enemy
            //score = score - 1;

            // removes a life if player touches red square
            lives = lives - 1;

            SetAllText();

            //destroys player object if lives reaches 0
            if (lives == 0) {

                Destroy(this.gameObject);

            }
        }

        // Tier 2: if player doesn't score a 12 by the time they picked up 12 items then they stay in the area
        // score == 12 && count == 12 was in the parenthesis for Tier 2 coding

        if (score == 12 && lives != 0)
        {

            transform.position = new Vector3(44.0f, transform.position.y, 0.0f);

        }



    }

    void SetAllText()
    {

        countText.text = "Count: " + count.ToString();

        scoreText.text = "Score: " + score.ToString();

        livesText.text = "Lives: " + lives.ToString();

        // if player has at least one life and a score of 21 then they win 
        if (lives > 0 && score == 21)
        {

            winText.text = "You Win!";

        }

        // if player lives reach 0 then they lose
        else if (lives == 0)
        {

            winText.text = "You Lose!";

        }

        /*
            //Tier 2: Win condition if player scores 21 

           if (score == 21) {

               winText.text = "You Win!";

           }



           //Tier 2: Player had to have a score of 12 to win in the first area

           else if (score < 12 && count == 12){

               winText.text = "You Lose!";

           }

           //Tier 2: Player loses if they they didn't score 21 by the time they 
           //picked up 21 objects

           else if (score < 21 && count > 21) {

               winText.text = "You Lose!";

           }



            }
        */

    }
}

