using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckLadder : MonoBehaviour
{
    private bool _PlayerInZone;
    public GameObject _Player;

    private void Update()
    {
        if(_PlayerInZone == true)
        {
            _Player.GetComponent<LadderMovement>().enabled = true;
        }
        else
        {
            _Player.GetComponent<LadderMovement>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _PlayerInZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _PlayerInZone = false;
        }
    }
}
