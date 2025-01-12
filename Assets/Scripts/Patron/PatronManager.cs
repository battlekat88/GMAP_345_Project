using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManager : MonoBehaviour
{
    public static PatronManager Instance { get; private set; }

    private GameObject[] PatronList;

     private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (PatronList == null){
            PatronList = GameObject.FindGameObjectsWithTag("Patron");
            // Debug.Log("patronlist has "+ PatronList.Length + " many patrons");
            PatronRecruitPoints("triangle", 1);
        }
    }

    // math behind patrons getting recruited
    public void PatronRecruitPoints(string tableid, float num)
    {
        // if table with tag == patrontableid gets points, give
        // give food point to correctOrderCounter

        foreach (GameObject patron in PatronList){
            if (patron.GetComponent<Patron>().patronTableID == tableid){
                patron.GetComponent<Patron>().correctOrderCounter += num;
            }
        }

    }
}
