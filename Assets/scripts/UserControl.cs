using System;
using UnityEngine;

namespace SeriousDev.Spacesnake
{
    public class UserControl : MonoBehaviour
    {
        private Player m_Character;
        private bool m_Jump;
        public Vector2 lastDirection = Vector2.up;


        private void Awake()
        {
            m_Character = GetComponent<Player>();
        }


        private void Update()
        {
        }


        private void FixedUpdate()
        {
            Vector2 direction = lastDirection;
            if (Input.GetKey(KeyCode.W))
            {
                direction = Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = Vector2.down;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = Vector2.right;
            }
            m_Character.Move(direction);
            lastDirection = direction;
        }
    }
}
