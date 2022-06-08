using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCheckLadder : MonoBehaviour
{
    public GameObject _falsefloor;
    public GameObject _promp;
    /*[HideInInspector]public bool _isPlayerInZone;*/
    PlayerInput _interact;

    private void Start()
    {
        _interact = new PlayerInput();
        _interact.Enable();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _promp.SetActive(true);
            if (_interact.PlayerMap.Interact.WasPressedThisFrame())
            {
                Debug.Log("Pressed");
                _falsefloor.SetActive(false);
                _promp.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*_isPlayerInZone = false;*/
        _falsefloor.SetActive(true);
        _promp.SetActive(false);
    }

    
}
