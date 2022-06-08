using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour
{
    [Header ("Issue Controller")]
    public bool maxIssues;
    public int currentIssues;

    [Header ("Issue Controller")]
    public GameObject[] IssueObjects;


    public void selectIssueInRoom()
	{
        List<GameObject> list = checkAvailable();

        list[Random.Range(0, list.Count + 1)].GetComponent<roomController>().selectIssueInRoom();
        currentIssues++;
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
}
