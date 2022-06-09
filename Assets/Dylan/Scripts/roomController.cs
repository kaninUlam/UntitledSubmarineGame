using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour
{
    [Header ("Issue Controller")]
    public bool maxIssuesMeet;
    public int maxIssues;
    public int currentIssues;

    [Header ("Issue Controller")]
    public GameObject[] IssueObjects;
    public SpawnControllerScript spawnController;


    public void selectIssueInRoom()
	{
        List<GameObject> list = new List<GameObject>(checkAvailable());

        int roll = Random.Range(0, list.Count);
        list[roll].GetComponent<repairable>().BreakDown();
        list[roll].GetComponent<repairable>().parentRoom = gameObject.GetComponent<roomController>();
        currentIssues++;
        checkMax();
	}


    public List<GameObject> checkAvailable()
	{
        List<GameObject> availableIssues = new List<GameObject>();

        foreach(GameObject issue in IssueObjects)
		{
			if (!issue.GetComponent<repairable>().isBroken)
			{
                availableIssues.Add(issue);
			}
		}

        return availableIssues;
	}

    public void checkMax()
	{
        if(currentIssues >= maxIssues)
		{
            maxIssuesMeet = true;
		}
		else
		{
            maxIssuesMeet = false;
		}
	}

    public void removeIssue()
	{
        currentIssues--;
        checkMax();
        spawnController.removeCurrentIssue();
	}
}
