using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private CharacterController myCharacter;
    private Vector3 myDirection;
    public float velocity = 18f;
    public float jumpForce = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        myCharacter = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        myDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        myDirection += (Vector3.down * velocity * Time.deltaTime);

        if (myCharacter.isGrounded)
        {
            myDirection = Vector3.down;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                myDirection = Vector3.up * jumpForce;
            }
        }

        myCharacter.Move(myDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManagerScript.myGameManager.gameOver();
        }
    }
}
