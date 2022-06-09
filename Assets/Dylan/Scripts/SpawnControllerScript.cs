using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerScript : MonoBehaviour
{
    [Header("Setup")]
    public GameObject player;

    [Header ("Timer Controllers")]
    public float timer;
    public float minTimeBetween;
    public float maxTimeBetween;

    [Header("Room Controllers")]
    [Tooltip("This value will auto fill")]public GameObject upstairsMiddleRoom;
    [Tooltip("This value will auto fill")]public GameObject downstairsMiddleRoom;

    public GameObject[] upstairsRooms;
    public GameObject[] downstairsRooms;

    [Header("Chances Controllers")]
    
    [Tooltip("value between 0 and 1. For example 0.4 = 40% chance to spawn on different floor")] public float chanceToBeOtherFloor;
    [Tooltip("maximum issues can spawn at any one time")] public int maxIssuesAtOnce;
    [Tooltip("This value will auto fill")] public int currentIssuesAtOnce;

    // Start is called before the first frame update
    void Start()
    {
        upstairsMiddleRoom = upstairsRooms[upstairsRooms.Length / 2];
        downstairsMiddleRoom = downstairsRooms[downstairsRooms.Length / 2];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentIssuesAtOnce < maxIssuesAtOnce)
		{
            if(timer <= 0)
		    {
                spawnIssueObject();
		    }
		    else
		    {
                timer -= Time.deltaTime;
		    }
		} 
    }

    public void spawnIssueObject()
	{
        int currentFloor = findWhatFloor();
        
        if(Random.Range(0,1f) <= chanceToBeOtherFloor)
		{
            //get the floor the player is not on
			if(currentFloor == 1)
			{
                spawnOnFloor(2);
			}
			else
			{
                spawnOnFloor(1);
			}
		}
		else
		{
            spawnOnFloor(currentFloor);
		}

        timer = Random.Range(minTimeBetween, maxTimeBetween);
	}

    //return 2 if upstairs and 1 if downstairs
    public int findWhatFloor()
	{
        float distanceUpstairs = Vector3.Distance(player.transform.position, upstairsMiddleRoom.transform.position);
        float distanceDownstiars = Vector3.Distance(player.transform.position, downstairsMiddleRoom.transform.position);

        if(distanceUpstairs < distanceDownstiars)
		{
            return 2;
		}
		else
		{
            return 1;
		}
        
	}

    public void spawnOnFloor(int floor)
	{
        GameObject[] rooms;

        if(floor == 1)
		{
            rooms = downstairsRooms;
		}
		else
		{
            rooms = upstairsRooms;
		}

        //check to see if a room is currently got too many or not
        List<GameObject> availableRooms = new List<GameObject>();
        foreach(GameObject room in rooms)
		{
			if (!room.GetComponent<roomController>().maxIssuesMeet)
			{
                availableRooms.Add(room);
			}
		}

        if(availableRooms.Count > 0)
		{
            availableRooms[Random.Range(0, availableRooms.Count)].GetComponent<roomController>().selectIssueInRoom();
            currentIssuesAtOnce++;
		}
        
        
	}

    public void removeCurrentIssue()
	{
        currentIssuesAtOnce--;
	}
}
