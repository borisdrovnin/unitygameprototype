using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public List<GameObject> obstaclePrefabs = new List<GameObject>();
    public float spawnRateMin = 1;
    public float spawnRateMax = 3;
    private BoxCollider2D sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<BoxCollider2D>();
        StartCoroutine("DoCheck");

    }

    // Update is called once per frame
    void Update () {
		
	}

    void Spawn()
    {
        Debug.Log(sprite.bounds.center + " " + sprite.bounds.min + " " + sprite.bounds.max);
        //GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count - 1)];
        //Instantiate(prefab, new Vector2(Random.Range(sprite.bounds.min.x, sprite.bounds.max.x), sprite.bounds.center.y), Quaternion.identity);
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject("obstacle_rect");
        if (obj != null)
        {
            obj.transform.position = new Vector2(Random.Range(sprite.bounds.min.x, sprite.bounds.max.x), sprite.bounds.center.y);
            obj.transform.rotation = this.transform.rotation;
            obj.transform.localScale = new Vector3(
                Mathf.Round(Random.Range(1, 5)),
                Mathf.Round(Random.Range(1, 5)),
                1);
            obj.SetActive(true);
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            Spawn();
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
    }
}
