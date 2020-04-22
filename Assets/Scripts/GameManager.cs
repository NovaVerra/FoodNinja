using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	/** Game Config */
	[SerializeField] List<GameObject>	Targets;
	[SerializeField] TextMeshProUGUI	ScoreText;
	[SerializeField] TextMeshProUGUI	GameOverText;
	[SerializeField] Button				RestartButton;
	[SerializeField] GameObject			TitleScreen;
	[SerializeField] Transform			Parent;
	[SerializeField] float				SpawnRate = 1.0f;
	float		Score;
	public bool	b_IsGameOver;

	// Start is called before the first frame update
	void	Start()
	{
		
	}

	// Update is called once per frame
	void	Update()
	{
		
	}

	IEnumerator	SpawnTarget()
	{
		while (!b_IsGameOver)
		{
			yield return new WaitForSeconds(SpawnRate);
			int	Index = Random.Range(0, Targets.Count);
			GameObject TargetInstance = Instantiate(Targets[Index]);
			TargetInstance.transform.parent = Parent;
		}
	}

	public void	UpdateScore(int ScoreToAdd)
	{
		Score += ScoreToAdd;
		ScoreText.text = "Score: " + Score;
	}

	public void	GameOver()
	{
		b_IsGameOver = true;
		UpdateUI(b_IsGameOver);
	}

	public void	UpdateUI(bool b_IsGameOver)
	{
		GameOverText.gameObject.SetActive(b_IsGameOver);
		RestartButton.gameObject.SetActive(b_IsGameOver);
	}

	public void	RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void	StartGame(int Difficulty)
	{
		// Set game state
		b_IsGameOver = false;
		UpdateUI(b_IsGameOver);
	
		// Set Score UI
		Score = 0;
		UpdateScore(0);

		// Set Difficulty
		SpawnRate /= Difficulty;
	
		// Start spawning periodically
		StartCoroutine(SpawnTarget());
	
		// De/spawn title screen
		TitleScreen.SetActive(b_IsGameOver);
	}
}
