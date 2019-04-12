// Curtis Davis     January 5, 2018     Enemy Spawner       https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    public GameObject enemy;
    public float delay = 5f;
    public int maximum = 12;
    public Transform[] spawnPoints;
    private List<GameObject> m_list = new List<GameObject>();
    private float m_internalTimer = 5f;

    void Start()
    {
        m_internalTimer = delay;
    }
    void Update()
    {
        if (m_list.Count >= maximum)
            return;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        m_internalTimer -= Time.deltaTime;
        m_internalTimer = Mathf.Max(m_internalTimer, 0f);
        if (m_internalTimer == 0f)
        {
            GameObject obj = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            m_list.Add(obj);
            m_internalTimer = delay;
        }
    }

    void LateUpdate()
    {
        //remove all destroyed objects
        m_list.RemoveAll(o => (o == null || o.Equals(null)));
    }
}
