using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class ScrollingEnvironmentBehavior : MonoBehaviour
    {
        [SerializeField] Vector2 direction = new Vector2(0f, 1f); // Set direction to move from left to right
        [SerializeField] float speed;
        [SerializeField] Material envMaterial;

        // Update is called once per frame
        void Update()
        {
            MoveEnvironment();
        }

        void MoveEnvironment()
        {
            if (GameState.GetState() == GameStates.Over) { return; }

            envMaterial.mainTextureOffset += direction * speed * Time.deltaTime;
        }
    }
}
