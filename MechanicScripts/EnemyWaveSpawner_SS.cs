//Scott Schubr
// January 7th, 2018
//Wave Spawner Script - Credit to Brackey's and Unity Official for the Tutorials, as well as Renaissance Coders. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyWaveSpawner_SS : MonoBehaviour {

    public GameObject Grunt;
    public GameObject SoleBoss;
    public GameObject Soldier;
    public GameObject Commander;
    public GameObject PagosBoss;
    public GameObject General;
    public GameObject AtmosBoss;
    public GameObject HydroBoss;
    public GameObject KasaiBoss;


    [Header ("Game Over Refs")]
	public GameObject overScreen;
	public GameObject player;
	public GameObject playerHUD;
	public GameObject crosshair;

	[Header ("Wave Settings")]
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

    public AudioSource audioSource;
    public AudioClip alarmClip;

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
        ec = GameObject.FindGameObjectWithTag("AirEnemy").GetComponent<EnemyController>();

		if (spawnPoints.Length == 0)
		{
			Debug.LogError("Debug: No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = alarmClip;
       
    }

	void Update()
	{

		if (enemyCount == 0) {

			WinScreen ();

		}

		if (KasaiBoss.activeSelf) {

		//Invoke ("DestroySpawns", 11f);

		}
		if (Time.time <= 15) {

			PreGameTimer ();

		}
		if (Time.time > 15) {

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
			 StartCoroutine( SpawnWave ( waves[nextWave] ));
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}

        if (incomingText == enabled)
        {
            audioSource.PlayOneShot(alarmClip, 0.1f);
        }
        else if (incomingText == !enabled)
        {
            audioSource.Stop();
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
            //Invoke ("WinScreen", 15f);
            
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
			if ((GameObject.FindGameObjectWithTag("Boss") == null) && (GameObject.FindGameObjectWithTag("AirEnemy") == null))
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
			yield return new WaitForSeconds( 1f/_wave.rate );
		}

		state = SpawnState.WAITING;

		yield break;
	}
		

    void SpawnEnemy(Transform _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate(_enemy, _sp.position, _sp.rotation);
        // here we will declare the destination of the enemy by means of their transform "base", and set it equal to our transform "theBase" which should be populated in this script with the desired base transform.
        //which doesnt seem to work...
        //ec.Base = theBase;
        
	}

	public void WinScreen () {

		overScreen.SetActive (true);
		playerHUD.SetActive (false);
		crosshair.SetActive (false);

		Time.timeScale = 0;


	}

	public void EnemyTracker (float amount) {

		enemyCount -= amount;

		enemyCounter.text = "Enemies Remaining: " + enemyCount.ToString();

        if(enemyCount == 121)
        {
            Grunt.SetActive(false);
            SoleBoss.SetActive(true);

        }

        if (enemyCount == 120)
        {
            
            SoleBoss.SetActive(false);
            Grunt.SetActive(true);

        }

        if (enemyCount == 115)
        {

            Grunt.SetActive(false);
            Soldier.SetActive(true);

        }

        if (enemyCount == 97)
        {

    
            Soldier.SetActive(false);
            PagosBoss.SetActive(true);

        }

        if (enemyCount == 96)
        {

            PagosBoss.SetActive(false);
            Soldier.SetActive(true);
           

        }

        if (enemyCount == 90)
        {

            Soldier.SetActive(false);
            Commander.SetActive(true);


        }

        if (enemyCount == 72)
        {

            Commander.SetActive(false);
            HydroBoss.SetActive(true);


        }

        if (enemyCount == 71)
        {
            HydroBoss.SetActive(false);
            Commander.SetActive(true);


        }

        if (enemyCount == 65)
        {
            
            Commander.SetActive(false);
            General.SetActive(true);

        }

        if (enemyCount == 47)
        {

            General.SetActive(false);
            AtmosBoss.SetActive(true);

        }

        if (enemyCount == 46)
        {
            AtmosBoss.SetActive(false);
            General.SetActive(true);
          

        }

        if (enemyCount == 1)
        {
            
            General.SetActive(false);
            KasaiBoss.SetActive(true);


        }

    }

	void PreGameTimer () {

		float minutes = Mathf.Floor(preTime / 60);
     	float seconds = preTime%60;

		preText.text = Mathf.RoundToInt(seconds).ToString();

	}

	//void EndGameTimer () {

	//	float minutes = Mathf.Floor(endTime / 60);
     	//float seconds = endTime%60;

		//incomingText.text = "";

	//	endText.text = "Time Until Next Level" + "\n" + Mathf.RoundToInt(seconds).ToString();

	//}

	void DestroySpawns () {

		incomingText.text = "";

		Destroy (gameObject);

	}

	public void DecreaseCount (float amount) {

		enemyCount -= amount;

	}

}
