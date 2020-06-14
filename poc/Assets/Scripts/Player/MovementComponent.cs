using System;
using UnityEngine;

namespace Player
{
    public class MovementComponent : MonoBehaviour
    {
        public Animator playerAnimator;
        public float speed = 500f;

        private bool _isFlipped = false;
        private float _horizontalInput = 0f;
        private float _velocity = 0f;

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            _velocity = _horizontalInput * speed * Time.fixedDeltaTime;
        
            if (_velocity > 0 && _isFlipped)
            {
                Flip();
            }
            if (_velocity < 0 && !_isFlipped)
            {
                Flip();
            }

            Move();
        }

        private void Move()
        {
            playerAnimator.SetFloat("velocity", Math.Abs(_velocity));
            transform.Translate((_velocity > 0)? (Vector2.right * _velocity) : (Vector2.left * Math.Abs(_velocity)));
        }

        private void Flip()
        {
            Vector3 localScale = transform.localScale;

            _isFlipped = !_isFlipped;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        private void Jump()
        {
        }
    }
}
