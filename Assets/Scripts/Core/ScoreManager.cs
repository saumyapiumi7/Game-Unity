using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class ScoreManager : MonoBehaviour
    {
        private int score;

        public SoundsManager soundsManager; // Reference to the SoundsManager

        private void Start()
        {
            // Make sure to assign a SoundsManager component to the soundsManager variable
            if (soundsManager == null)
            {
                soundsManager = FindObjectOfType<SoundsManager>();
                if (soundsManager == null)
                {
                    Debug.LogError("SoundsManager component not found. Make sure it's present in the scene.");
                }
            }
        }



        public void AddScore(int value)
        {
            score += value;
            Debug.Log(score);

            if (soundsManager != null)
            {
                soundsManager.PlaySoundClip("score");
            }
        }




        public int GetScore()
        {
            return score;
        }

        public void ResetScore()
        {
            score = 0;
        }

    }
}