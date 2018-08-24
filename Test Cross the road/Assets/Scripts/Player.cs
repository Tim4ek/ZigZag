using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour {

    private Rigidbody rb;
    Renderer m_Renderer;
    public float jumpForce = 112f;
    public float groundCheckDistance = 0.3f;
    private bool isGrounded = false;

    public GameObject playerDead;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {        
        if (Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance))
        {
            
            isGrounded = true;
        }
        if (isGrounded)
        {
            if(Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    AdjustPositionAndRotation(new Vector3(0, 0, 0));
                    rb.AddForce(new Vector3(0, jumpForce, jumpForce));
                }
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.touchCount>0)
                {
                    AdjustPositionAndRotation(new Vector3(0, 0, 0));
                    rb.AddForce(new Vector3(0, jumpForce, jumpForce));
                }
            }
            
        }       

    }
    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StepTrigger"))
        {
            LevelManager.levelManager.SetSteps();
            
        }
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Instantiate(playerDead, transform.position, transform.rotation);
        gameObject.SetActive(false);
        LevelManager.levelManager.GameOver();
    }
}
