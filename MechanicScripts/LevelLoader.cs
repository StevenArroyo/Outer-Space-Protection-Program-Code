using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;

	public Slider slider;

	public Text progressText;

	public GameObject menu;
	public GameObject levelSelector;

	public GameObject planet;

	public GameObject preGame;


	public void LoadLevel (int sceneIndex) {

		StartCoroutine (LoadAsynchrously (sceneIndex));


	}

	IEnumerator LoadAsynchrously (int sceneIndex) {

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingScreen.SetActive (true);

		while (operation.isDone == false) {

			float progress = Mathf.Clamp01 (operation.progress / .9f);

			
			slider.value = progress;
			progressText.text = progress * 100f + "%";

			yield return null;


		}

	}

	public void OpenLevelSelect () {

		planet.SetActive (false);
		menu.SetActive (false);
		levelSelector.SetActive (true);

	}

	public void CloseLevelSelect () {

		planet.SetActive (true);
		menu.SetActive (true);
		levelSelector.SetActive (false);


	}

	public void OpenHowToPlay () {

		planet.SetActive (false);
		preGame.SetActive (true);


	}

	public void CloseHowToPlay () {

		planet.SetActive (true);
		preGame.SetActive (false);

	}

}
