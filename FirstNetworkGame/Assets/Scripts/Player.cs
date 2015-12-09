using UnityEngine;

using UnityEngine.Networking;
public class Player : NetworkBehaviour 
{
	[SyncVar]
	public Color color;

	float moveSpeed = 1.875f;
	public override void OnStartClient() 
	{
		gameObject.GetComponent<Renderer>().material.color = color;
	}
	// Use this for initialization
	void Start () 
	{


	}

	void GetInput() 
	{
		float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
		float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
		MoveIt(x,y);
	}
	void MoveIt(float x, float y) 
	{
		transform.Translate(x,y,0);
	}
	// Update is called once per frame
	void Update () 
	{
		if(isLocalPlayer) 
			GetInput();
		
	}
}
