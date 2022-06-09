using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineHealth : MonoBehaviour
{

    // remove the commented out sections when building the final game.
    public float _currentSubHealth;
    public float _maxSubHealth;

    public HealthBar healthbar;

    /*PlayerInput _playerInput;*/
    private void Start()
    {
        _currentSubHealth = _maxSubHealth;
        healthbar.SetMaxHealth(_maxSubHealth);

        /*_playerInput = new PlayerInput();
        _playerInput.Enable();*/
    }

    public void TakeDamage(float num)
    {
        _currentSubHealth = _currentSubHealth - num;

        healthbar.SetHealth(_currentSubHealth);
    }
}
