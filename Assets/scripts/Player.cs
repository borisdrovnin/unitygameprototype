using System;
using System.Collections.Generic;
using UnityEngine;

namespace SeriousDev.Spacesnake
{
    public class Player : MonoBehaviour
    {
        public static Player instance;
        [SerializeField] public float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        public Trail trailPrefab;
        
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        public int collidingTrails = 0;
        public Vector2 direction = Vector2.up;
        public Vector2 lastDirection = Vector2.up;
        public SpriteRenderer sprite;
        public float colorChangeDirection = 0.01f;
        private float colorChange = 0;
        public Color startColor;
        public Color endColor;

        GameObject lastTrail = null;
        

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            //Instantiate(trailPrefab, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), Quaternion.identity);
            instance = this;
        }

        void Start()
        {
            SpawnTrail(transform.position);
        }


        private void FixedUpdate()
        {
        }


        private void SpawnTrail(Vector2 position)
        {
            GameObject trail = ObjectPooler.SharedInstance.GetPooledObject("trail");
            if (trail != null)
            {
                lastTrail = trail;
                trail.transform.position = position;
                trail.transform.rotation = this.transform.rotation;
                trail.SetActive(true);
            }
            //oCount++;
            //Debug.Log("Instantiate " + oCount + " " + position);
            //Trail t = Instantiate<Trail>(trailPrefab, position, Quaternion.identity);
            //t.name = "Trail" + oCount;
            //t.player = this;
            //lastTrail = t;
        }

        public void Move(Vector2 direction)
        {
            if (this.direction != direction)
            {
                SpawnTrail(transform.position);
                m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed * direction.x, m_MaxSpeed * direction.y * 0);
                this.direction = direction;
            }
        }

        private void Update()
        {
            if (Vector2.Distance(m_Rigidbody2D.position, lastTrail.transform.position) > 0.5f)
            {
                SpawnTrail(transform.position);
            }
            sprite.color = Color.Lerp(startColor, endColor, colorChange);
            colorChange += colorChangeDirection;
            if (colorChange >= 1 || colorChange <= 0)
            {
                colorChangeDirection = -colorChangeDirection;
            }
        }

        //private void Blink()
        //{
        //    for (; ; )
        //    {
                
        //        yield return new WaitForSeconds(0.1f);
        //    }
        //}

        //private void OnTriggerEnter2D(Collider2D other)
        //{
        //    if (other.tag == "trail")
        //    {
        //        collidingTrails++;
        //    }
        //}

        //private void OnTriggerExit2D(Collider2D other)
        //{
        //    if (other.tag == "trail")
        //    {
        //        collidingTrails--;
        //        if(collidingTrails == 0)
        //        {
        //            Instantiate(trailPrefab, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), Quaternion.identity);
        //        }
        //    }
        //}

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
