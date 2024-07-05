using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class bbottomEdgeCollision : MonoBehaviour, IHitPlayer
    {
        public void OnHitPlayer()
        {
            GameManager.Instance.soundsManager.PlaySoundClip("explode");
            GameManager.Instance.soundsManager.PlaySoundClip("game over");
            GameManager.Instance.uiManager.OnGameOver();
            GameManager.Instance.spawner.ResetObstacles();
            GameState.SetState(GameStates.Over);
        }
    }

}
