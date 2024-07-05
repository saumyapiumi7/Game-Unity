using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class ObstacleMovement : MonoBehaviour
    {
        //movement
        [SerializeField] Vector3 moveDirection;
        [SerializeField] float moveSpeed;

        //obstacles
        [SerializeField] GameObject topRock;
        [SerializeField] GameObject bottomRock;
        [SerializeField] GameObject passedDetector;


        // Update is called once per frame
        void Update()
        {
            MoveObstacle();
        }

        void MoveObstacle()
        {
            if (GameState.GetState() == GameStates.Over) return;
            if (GameState.GetState() == GameStates.Menu) return;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        public void Spawn(Vector3 _position)
        {
            float rand = Random.Range(0f, 1f);
            topRock.SetActive(rand > 0.5f);
            bottomRock.SetActive(rand <= 0.5f);
            transform.position = _position;
            gameObject.SetActive(true);
            passedDetector.SetActive(true);
        }

        public void ResetValues()
        {
            topRock.SetActive(false);
            bottomRock.SetActive(false);
            gameObject.SetActive(false);
            passedDetector.SetActive(false);
        }
    }

}
