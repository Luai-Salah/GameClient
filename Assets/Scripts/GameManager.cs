using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

	public GameObject localPlayerPrefab;
	public GameObject playerPrefab;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
		{
			Debug.Log("More Than One Instance Found, Destroying...");
			Destroy(this);
		}
	}

	public void SpawnPlayer(int _id, string _userName, Vector3 _pos, Quaternion _rot)
	{
		GameObject _player;
		if (Client.instance.myId == _id)
		{
			_player = Instantiate(localPlayerPrefab, _pos, _rot);
		}
		else
		{
			_player = Instantiate(playerPrefab, _pos, _rot);
		}

		_player.GetComponent<PlayerManager>().id = _id;
		_player.GetComponent<PlayerManager>().userName = _userName;

		players.Add(_id, _player.GetComponent<PlayerManager>());
	}
}
