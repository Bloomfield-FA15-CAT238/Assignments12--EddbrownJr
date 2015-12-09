using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Player : NetworkBehaviour 
{
	[SyncVar]
	public Color color;
	[SyncVar]
	public int score;

	public GameObject bulletPrefab;
	float moveSpeed = 1.875f;

	private Text scoreText;
	public override void OnStartClient() 
	{
		gameObject.GetComponent<Renderer>().material.color = color;
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}


	void GetInput() 
	{
		float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
		float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

		if(Input.GetButtonUp("Fire1"))
			CmdDoFire();

		if(isServer) 
			RpcMoveIt(x,y);
		 else 
			CmdMoveIt(x,y);


	}

	[Command]
	public void CmdDoFire() 
	{ 
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + this.transform.right, Quaternion.identity);
		bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 17.5f;
		bullet.GetComponent<Bullet>().color = color;
		bullet.GetComponent<Bullet>().parentNetId = this.netId;
		NetworkServer.Spawn(bullet);
		Destroy(bullet,0.875f);
	}
	
	[ClientRpc]
	void RpcMoveIt(float x, float y) 
	{
		transform.Translate(x,y,0);
	}
	
	[Command]
	public void CmdMoveIt(float x, float y) 
	{
		RpcMoveIt(x,y);
	}
	
	void Update () 
	{
		if (isLocalPlayer) 
		{
			GetInput ();
			scoreText.text = "Score: " + score;
		}
		
	}
}
