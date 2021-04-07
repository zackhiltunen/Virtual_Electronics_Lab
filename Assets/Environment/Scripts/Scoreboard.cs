﻿using System.IO;
using UnityEngine;

namespace cs4910.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform scoreHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;
        
        [Header("Test")]
        [SerializeField] ScoreboardEntryData testEntryData = new ScoreboardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";


        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            SaveScores(savedScores);

            UpdateUI(savedScores);         
        }
    
        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }
        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            if(savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(
                    maxScoreboardEntries, 
                    savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }
        
        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach(Transform child in scoreHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach(ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, scoreHolderTransform).
                    GetComponent<ScoreboardEntryUI>().Initialize(highscore);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if(!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using(StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using(StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}