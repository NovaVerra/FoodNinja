using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	/** Game Config */
	[SerializeField] float		Min_Force = 12.0f;
	[SerializeField] float		Max_Force = 16.0f;
	[SerializeField] float		TorqueRange = 10.0f;
	[SerializeField] float		X_SpawnRange = 4.0f;
	[SerializeField] float		Y_SpawnPos = -2.0f;
	[SerializeField] int		PointValue = 10;
	[SerializeField] ParticleSystem	P_Explosion;
	GameManager	GameManager;
	Rigidbody	RB_Object;

	// Start is called before the first frame update
	void	Start()
	{
		GetAllComponents();
		SpawnObject();
	}

	void	GetAllComponents()
	{
		RB_Object = GetComponent<Rigidbody>();
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void	OnMouseDown()
	{
		if (!GameManager.b_IsGameOver)
		{
			Destroy(gameObject);
			PlayExplosion();
			GameManager.UpdateScore(PointValue);
		}
	}

	void	OnTriggerEnter(Collider ColliderObject)
	{
		Destroy(gameObject);
		if (!gameObject.CompareTag("Bad"))
		{
			GameManager.GameOver();
		}
	}

	void	SpawnObject()
	{
		transform.position = RandomSpawn();
		RB_Object.AddForce(RandomForce(), ForceMode.Impulse);
		RB_Object.AddTorque(RandomTorque());
	}

	void	PlayExplosion()
	{
		Instantiate(P_Explosion, transform.position, Quaternion.identity);
	}

	Vector3	RandomForce()
	{
		return (Vector3.up * Random.Range(Min_Force, Max_Force));
	}

	Vector3	RandomTorque()
	{
		return new Vector3(Random.Range(-TorqueRange, TorqueRange), Random.Range(-TorqueRange, TorqueRange), Random.Range(-TorqueRange, TorqueRange));
	}

	Vector3	RandomSpawn()
	{
		return transform.position = new Vector3(Random.Range(-X_SpawnRange, X_SpawnRange), Y_SpawnPos, 0);
	}
}
