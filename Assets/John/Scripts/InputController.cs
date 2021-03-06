using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class InputController : MonoBehaviour
{
    PlayerInput _playerInput;
    Movement _movement;
    LadderMovement _climb;
    void Start()
    {
        _movement = GetComponent<Movement>();
        _climb = GetComponent<LadderMovement>();
        _playerInput = new PlayerInput();
        /*_playerInput.PlayerMap.Jump.performed += c => _movement.Jump();*/
        _playerInput.Enable();
    }
    private void Update()
    {
        _movement.Move(_playerInput.PlayerMap.Move.ReadValue<float>());
        _climb.Climb(_playerInput.PlayerMap.Climb.ReadValue<float>());
    }
}