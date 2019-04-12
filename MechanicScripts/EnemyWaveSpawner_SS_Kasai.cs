using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveSpawner_SS_Kasai : MonoBehaviour {

    public GameObject Grunt;
    public GameObject SoleBoss;
    public GameObject Soldier;
    public GameObject Commander;
    public GameObject PagosBoss;
    public GameObject General;
    public GameObject AtmosBoss;
    public GameObject HydroBoss;
    public GameObject KasaiBoss;


    [Header("Game Over Refs")]
    public GameObject overScreen;
    public GameObject player;
    public GameObject playerHUD;
    public GameObject crosshair;

    [Header("Wave Settings")]
    public Text waveText;
    public Text incomingText;

    public Text enemyCounter;

    public float enemyCount;

    private float endTime = 20f;
    private float preTime = 15f;

    public Text endText;
    public Text preText;

    public int maxWave = 5;
    public Transform theBase;
    private EnemyController ec;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float WaveCountdown


    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get { return state; }
    }

    void Start()
    {

        enemyCounter.text = "Enemies Remaining: " + enemyCount.ToString();

        incomingText.text = ("Enemies Incoming!");

        //here we will call a reference to our Enemy game object, and obtain the component script Enemy Controller in reference to our ec variable.
        ec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Debug: No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
         if (KasaiBoss.activeSelf) {

			Invoke ("DestroySpawns", 11f);

		}


        if (Time.time <= 15)
        {

            PreGameTimer();

        }
        if (Time.time > 15)
        {

            preText.text = "";
        }

        preTime -= Time.deltaTime;
        //endTime -= Time.deltaTime;

        waveText.text = "Wave: " + NextWave + " / " + maxWave;

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if ((waveCountdown <= 0) && (Time.time >= 15))
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        incomingText.text = ("Enemies Incoming!");

        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            //Invoke("WinScreen", 9.9f);

            //EndGameTimer ();
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if ((GameObject.FindGameObjectWithTag("Enemy") == null) && (GameObject.FindGameObjectWithTag("AirEnemy") == null))
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        incomingText.text = ("");

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }


    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        // here we will declare the destination of the enemy by means of their transform "base", and set it equal to our transform "theBase" which should be populated in this script with the desired base transform.
        //which doesnt seem to work...
        //ec.Base = theBase;

    }

    public void WinScreen()
    {

        overScreen.SetActive(true);
        playerHUD.SetActive(false);
        crosshair.SetActive(false);

        Time.timeScale = 0;


    }

    public void EnemyTracker(float amount)
    {

        enemyCount -= amount;

        enemyCounter.text = "Enemies Remaining: " + enemyCount.ToString();

        if (enemyCount == 1)
        {
            General.SetActive(false);
            KasaiBoss.SetActive(true);

        }
    }

    void PreGameTimer()
    {

        //float minutes = Mathf.Floor(preTime / 60);
        float seconds = preTime % 60;

        preText.text = Mathf.RoundToInt(seconds).ToString();

    }

    //void EndGameTimer () {

    //	float minutes = Mathf.Floor(endTime / 60);
    //float seconds = endTime%60;

    //	incomingText.text = "";

    //	endText.text = "Time Until Next Level" + "\n" + Mathf.RoundToInt(seconds).ToString();

    //}

 void DestroySpawns () {

		Destroy (gameObject);

	}

}
