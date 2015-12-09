using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class MyNetworkManager : NetworkManager 
{


	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) 
	{
		Color color = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));
		GameObject playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		playerToSpawn.GetComponent<Player>().color = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));
		NetworkServer.AddPlayerForConnection(conn, playerToSpawn, playerControllerId);

	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
