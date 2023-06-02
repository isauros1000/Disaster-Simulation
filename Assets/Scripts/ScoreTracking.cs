using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracking : MonoBehaviour
{
    public float score = 100;
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement points if we're touching the ground
        TouchingGround();
        // Cast to an int to get rid of trailing numbers
        text.text = "Score: " + (int)score;
        // Switch to game over scene if score = 0
        CheckGameOver();
    }
    
    void TouchingGround() 
    {
        // Create the Ray object that the raycast will do
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10)) {
            // Get the info from the collision to see if we're touching ground
            if(hitInfo.collider.gameObject.CompareTag("Ground")) {
                // Decrease score because we're off the road
                score -= 1*Time.fixedDeltaTime;
            }
        }
    }
    void CheckGameOver()
    {
        if(score <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
