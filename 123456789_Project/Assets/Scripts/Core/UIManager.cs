using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Reference
{
    public class UIManager : MonoBehaviour
    {
        //gameplay
        [Header("Game Play HUD")]
        [SerializeField] GameObject HUDPanel;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] PlayerBehavior player;

        //game Over
        [Header("Game Over Screen")]
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] Button replayButton;

        //main
        [Header("Main Menu")]
        [SerializeField] GameObject mainMenuPanel;

        private void Start()
        {
            mainMenuPanel.SetActive(true);
            replayButton.onClick.AddListener(OnReplayButtonClick);
        }

        public void SetScoreText(int value)
        {
            scoreText.text = value.ToString();
        }

        public void OnGameOver()
        {
            gameOverPanel.SetActive(true);
            HUDPanel.SetActive(false);
        }

        public void OnReplayButtonClick()
        {
            gameOverPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            GameState.SetState(GameStates.Menu);
            player.ResetValues();
        }

        public void OnGameStart()
        {
            GameState.SetState(GameStates.Game);
            mainMenuPanel.SetActive(false);
            HUDPanel.SetActive(true);
            GameManager.Instance.scoreManager.ResetScore();
            int score = GameManager.Instance.scoreManager.GetScore();
            GameManager.Instance.uiManager.SetScoreText(score);
            GameManager.Instance.spawner.StartSpawiningObstacles();
            GameManager.Instance.soundsManager.PlaySoundClip("game start");
        }
    }

}
