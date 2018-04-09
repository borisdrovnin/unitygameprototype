using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;
    public float m_MinSpeed = 6f;
    public float m_MaxSpeed = 8f;
    private float speed = 0f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(m_MinSpeed, m_MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        SeriousDev.Spacesnake.Player player = SeriousDev.Spacesnake.Player.instance;
        m_Rigidbody2D.velocity = new Vector2(0, -player.direction.y * player.m_MaxSpeed - speed);
        //this.transform.Translate(0, -player.direction.y * player.m_MaxSpeed * Time.deltaTime, 0);
    }

}
