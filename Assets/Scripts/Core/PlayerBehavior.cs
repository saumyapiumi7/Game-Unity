using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class PlayerBehavior : MonoBehaviour
    {
        [Header("Inputs")]
        //inputs
        [SerializeField] int jumpMouseBtn;

        [Header("Movement")]
        //movement
        [SerializeField] float gravity = 9.8f;
        Vector3 movement;
        [SerializeField] float jumpForce;
        [SerializeField] Vector3 forceDirection;
        [SerializeField] float maxAcceleration;
        [SerializeField] float maxVelocity;
        float acceleration;
        Vector3 resetPosition;

        [Header("Animation")]
        //animation
        [SerializeField] Animator animator;
        

        private void Start()
        {
            resetPosition = transform.position;
        }

        void Update()
        {
            MovePlane();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<IHitPlayer>(out IHitPlayer hit))
            {
                hit.OnHitPlayer();
            }
        }

        void MovePlane()
        {
            if (GameState.GetState() == GameStates.Over) return;
            if (GameState.GetState() == GameStates.Menu) return;

            //input and movement
            if (Input.GetMouseButton(jumpMouseBtn))
            {
                acceleration = maxAcceleration;
            }
            else
            {
                acceleration = 0f;
            }

            movement.y += (gravity + acceleration) * Time.deltaTime;
            movement.y = movement.y > maxVelocity ? maxVelocity : movement.y;
            transform.position += movement * Time.deltaTime;


            animator.speed = movement.y < 0 ? 0 : movement.y * 0.5f;

            //input and sound effects
            if (Input.GetMouseButtonDown(jumpMouseBtn))
            {
                GameManager.Instance.soundsManager.PlaySoundClip("propeller");
            }

        }

        public void ResetValues()
        {
            transform.position = resetPosition;
            acceleration = 0f;
            movement = Vector3.zero;
        }
    }
}

