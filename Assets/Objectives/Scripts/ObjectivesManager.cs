using System.Collections;
using System.Collections.Generic;
using Objectives.Scripts;
using UnityEngine;

/// <summary>
/// Singleton GameObject, attach objective game objects as children of ObjectivesManager.
/// When all objectives are complete, next lvl portal will appear.
/// </summary>
public class ObjectivesManager : MonoBehaviour
{

    public static ObjectivesManager Instance { get; private set; }
    public List<Objective> objectives = new List<Objective>();
    public GameObject nextLevelPortal = new GameObject();

    private void Awake()
    {
        //Add children of Objective Manager to list of objectives
        objectives.AddRange(Instance.GetComponentsInChildren<Objective>());
        
        //Find Instance of singleton
        if (Instance == null)
        {
            Instance = this;
            if (Instance == null)
                Instance = new ObjectivesManager();
        }       

        nextLevelPortal.SetActive(false);
    }

    private void Update()
    {
        NextLevel();
    }

    /// <summary>
    ///Spawns portal to next level. Doesn't unspawn.
    /// </summary>
    private void NextLevel()
    {
        if(AllObjectivesComplete())
            nextLevelPortal.SetActive(true);
    }

    public bool AllObjectivesComplete()
    {
        int completeObjectives = 0;

        foreach (Objective ob in objectives)
        {
            if (ob.Complete)
                completeObjectives++;
        }

        if (completeObjectives == objectives.Count)
            return true;
        else
            return false;
    }
}