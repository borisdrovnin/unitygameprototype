using System;
using System.Collections.Generic;
using UnityEngine;

namespace SeriousDev.Spacesnake
{
    public class Player : MonoBehaviour
    {

        public float maxVelocity = 10f;
        public float maxStaticVelocity = 20f;
        bool moving = false;
        bool fastMoving = false;
        bool halfWay = false;
        float offset = 0;
        float beginOffset = 0;
        float maxOffset = 3;
        float minOffset = -3;
        float time = 0;
        float lastDelta = 0;
        Rigidbody2D mRigidBody;
        public float targetX = 0;
        public float fakeTargetX = 0;
        public float smoothTime = 0.3F;
        private float xVelocity = 0.0F;

        Vector2 beginDirection;
        public GameObject fakeTarget = null;
        public GameObject target = null;


        private void Awake()
        {
            mRigidBody = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
        }


        private void FixedUpdate()
        {
        }


        public void Move(Vector2 direction)
        {
            fakeTargetX = 0;
            //fastMoving = false;
            if (!moving)
            {
                if (direction.x != 0)
                {
                    moving = true;
                    halfWay = false;
                    beginDirection = direction;
                    if (direction.x < 0)
                    {
                        targetX -= 2;
                    }
                    if (direction.x > 0)
                    {
                        targetX += 2;
                    }
                 }

            }
            //else
            //{
            //    if (halfWay && direction == beginDirection)
            //    {
            //        if (direction.x != 0)
            //        {
            //            if (direction.x < 0)
            //            {
            //                fakeTargetX = -2;
            //            }
            //            if (direction.x > 0)
            //            {
            //                fakeTargetX = 2;
            //            }
            //        }
            //    }
            //}
        }

        float QubicInOut(float t)
        {
            return ((t *= 2f) <= 1 ? t * t * t : (t -= 2f) * t * t + 2f) / 2f;
        }

        private void Update()
        {
            //if (Mathf.Abs(transform.position.x - targetX) <= 1f)
            //{
            //    halfWay = true;
            //}
            if (Mathf.Abs(transform.position.x - targetX) <= 0.5f)
            {
                moving = false;
            }
            float newPosition = Mathf.SmoothDamp(transform.position.x, targetX + fakeTargetX, ref xVelocity, smoothTime);
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision "+collision.tag);
        }

    }
}
