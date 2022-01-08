using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2.5f;
    public Rigidbody2D rigidBody;
    public Animator animation;
    public Camera cam;

    Vector2 MousePos;
    Vector2 Movement;

    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        animation.SetFloat("Horizontal", Movement.x);
        animation.SetFloat("Vertical", Movement.y);
        animation.SetFloat("Speed", Movement.sqrMagnitude);
    }
    // Movement
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + Movement * MovementSpeed * Time.fixedDeltaTime);

        Vector2 Direction = MousePos - rigidBody.position;

        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
