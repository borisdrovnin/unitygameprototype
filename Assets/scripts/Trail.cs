using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

    private Rigidbody2D m_Rigidbody2D;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        SeriousDev.Spacesnake.Player player = SeriousDev.Spacesnake.Player.instance;
        GetComponent<SpriteRenderer>().color = player.sprite.color;
    }
	
	// Update is called once per frame
	void Update () {

        SeriousDev.Spacesnake.Player player = SeriousDev.Spacesnake.Player.instance;
        m_Rigidbody2D.velocity = new Vector2(0, -player.direction.y * player.m_MaxSpeed);
        //this.transform.Translate(0, -player.direction.y * player.m_MaxSpeed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle_rect"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
