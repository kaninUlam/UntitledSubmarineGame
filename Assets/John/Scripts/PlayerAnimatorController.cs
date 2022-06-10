using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Movement _movement;
    LadderMovement _isclimbing;
    Animator _anim;
    PlayerInput _playerInput;
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _anim = GetComponent<Animator>();
        _isclimbing = GetComponent<LadderMovement>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    private void Update()
    {
        //movement animation
        bool run = _movement.HorizontalVelocity != 0;
        _anim.SetBool("Running", run);
        if(_movement.HorizontalVelocity > 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(_movement.HorizontalVelocity < 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        //climbing animation
        bool climbing = _isclimbing._vertical != 0;
        _anim.SetBool("IsClimbing", climbing);

        if (_playerInput.PlayerMap.Interact.inProgress)
        {
            bool repairing = true;
            _anim.SetBool("IsInteract", repairing);
        }
       
    }


}
