using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
	/** Game Config */
	Button		Button;
	GameManager	GameManager;
	[SerializeField] int	Difficulty;

	// Start is called before the first frame update
	void	Start()
	{
		GetAllComponents();
		Button.onClick.AddListener(SetDifficulty);
	}

	void	GetAllComponents()
	{
		Button = GetComponent<Button>();
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void	SetDifficulty()
	{
		Debug.Log(gameObject.name + " was clicked!");
		GameManager.StartGame(Difficulty);
	}
}
