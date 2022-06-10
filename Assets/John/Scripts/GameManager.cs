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


    public static int perfectCount;
    public static int OkayCount;
    public static int MissCount;
    GameObject analytics;

    private void Start()
    {
        /*_timeRemaining = GetComponent<Timer>();
        _checkHealth = GetComponent<SubmarineHealth>();*/

        analytics = GameObject.Find("Analytics controller");
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
        sendInfo();
    }

    void YouLose()
    {
        _youLoseScreen.SetActive(true);
        sendInfo();
    }

    void sendInfo()
	{
        analytics.GetComponent<GameAna>().sendPerfects(perfectCount);
        analytics.GetComponent<GameAna>().sendOkays(OkayCount);
        analytics.GetComponent<GameAna>().sendMisses(MissCount);
	}

}
