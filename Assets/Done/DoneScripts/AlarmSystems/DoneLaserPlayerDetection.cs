using UnityEngine;
using System.Collections;

public class DoneLaserPlayerDetection : MonoBehaviour
{
	private Renderer _renderer;								// Reference to the Renderer.
	private GameObject player;								// Reference to the player.
	private DoneLastPlayerSighting lastPlayerSighting;		// Reference to the global last sighting of the player.


	void Awake ()
	{
		// Setting up references.
		_renderer = GetComponent<Renderer>();
		player = GameObject.FindGameObjectWithTag(DoneTags.player);
		lastPlayerSighting = GameObject.FindGameObjectWithTag(DoneTags.gameController).GetComponent<DoneLastPlayerSighting>();
	}


	void OnTriggerStay(Collider other)
	{
		// If the beam is on...
		if(_renderer.enabled)
			// ... and if the colliding gameobject is the player...
			if(other.gameObject == player)
				// ... set the last global sighting of the player to the colliding object's position.
				lastPlayerSighting.position = other.transform.position;
	}
}