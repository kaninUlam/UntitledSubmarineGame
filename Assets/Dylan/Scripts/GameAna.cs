using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameAna : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();
    }

    public void sendPerfects(int i)
	{
        GameAnalytics.NewDesignEvent("Perfects", i);
	}

    public void sendOkays(int i)
	{
        GameAnalytics.NewDesignEvent("Okays", i);
	}

    public void sendMisses(int i)
	{
        GameAnalytics.NewDesignEvent("misses", i);
	}
}
