using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SubmarineHealth _checkHealth;
    public Timer _timeRemaining;


    // set the you win prefab as deactivated
    public GameObject _youWinScreen;
    public GameObject _youLoseScreen;
    public GameObject _timer;
    private void Start()
    {
        /*_timeRemaining = GetComponent<Timer>();
        _checkHealth = GetComponent<SubmarineHealth>();*/
    }

    private void Update()
    {
        if(_timeRemaining.timer <= 0)
        {
            YouWin();
        }
        if(_checkHealth._currentSubHealth <= 0)
        {
            _timer.SetActive(false);
            YouLose();
        }
    }

    void YouWin()
    {
        _youWinScreen.SetActive(true); 
    }

    void YouLose()
    {
        _youLoseScreen.SetActive(true);
    }

}
