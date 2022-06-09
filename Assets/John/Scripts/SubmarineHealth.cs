using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineHealth : MonoBehaviour
{
    public float _currentSubHealth;
    public float _maxSubHealth;

    public HealthBar healthbar;

    private void Start()
    {
        _currentSubHealth = _maxSubHealth;
        healthbar.SetMaxHealth(_maxSubHealth);
    }
    void TakeDamage(float num)
    {
        _currentSubHealth = _currentSubHealth - num;
    }
}
