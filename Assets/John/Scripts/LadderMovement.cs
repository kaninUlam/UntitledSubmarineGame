using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// you need to assign the Rigidbody2d to this script as well as change the tag of the ladder gameobject to the tag of "Ladder"
public class LadderMovement : MonoBehaviour
{
    [HideInInspector]public float _vertical;
    public float _speed = 2f;
    private bool _isladder;
    private bool _isclimbing;

    [SerializeField] private Rigidbody2D _rb;

    void Update()
    {

        // get the button press for moving up and down of the ladder which is the buttons that are assigned in the input vertical.

        if (_isladder && Mathf.Abs(_vertical) > 0f)
        {
            _isclimbing = true;
        }
    }

    private void FixedUpdate()
    {
        // disables the gravity of the character and adds movement to the up and down value
        if (_isclimbing)
        {
            _rb.gravityScale = 0f;
            _rb.velocity = new Vector2(_rb.velocity.x, _vertical * _speed);
        }

        // re enables the gravity of the character !!!!! important !!!!! change the value to what is suited for the game.
        else
        {
            _rb.gravityScale = 1f;
        }
    }

    // player has entered the collider for the ladder and ready to interact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isladder = true;
            
        }
    }

    // player has exited the collider for the ladder and not ready to interact with it
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isladder = false;
            _isclimbing = false;
        }
    }

    public void Climb(float input)
    {
        _vertical = input * _speed;
    }
}
