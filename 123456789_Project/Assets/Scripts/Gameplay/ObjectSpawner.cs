using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] int obstacleCount;
        [SerializeField] GameObject obstaclePrefab;
        [SerializeField] List<ObstacleMovement> obstacles;
        int obstacleId;

        [Header("Spawn timing")]
        [SerializeField] float startingTime;
        [SerializeField] float repeatingTime;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < obstacleCount; i++)
            {
                GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
                obstacles.Add(obstacle.GetComponent<ObstacleMovement>());
            }
        }

        public void StartSpawiningObstacles()
        {
            InvokeRepeating("SpawnNewObstacle", startingTime, repeatingTime);
        }

        public void ResetObstacles()
        {
            CancelInvoke("SpawnNewObstacle");

            for (int i = 0; i < obstacleCount; i++)
            {
                obstacles[i].ResetValues();
            }
        }

        void SpawnNewObstacle()
        {
            obstacles[obstacleId].Spawn(transform.position);
            obstacleId++;
            obstacleId %= obstacleCount;
        }
    }
}