using UnityEngine;
using System.Collections;

public class DoneLaserBlinking : MonoBehaviour
{
	public float onTime;			// Amount of time in seconds the laser is on for.
	public float offTime;			// Amount of time in seconds the laser is off for.
	
	
	private Renderer _renderer;		// Reference to the Renderer.
	private float timer;			// Timer to time the laser blinking.


	void Awake ()
	{
		// Setting up the references.
		_renderer = GetComponent<Renderer>();
	}
	
	
	void Update ()
	{
		// Increment the timer by the amount of time since the last frame.
		timer += Time.deltaTime;
		
		// If the beam is on and the onTime has been reached...
		if(_renderer.enabled && timer >= onTime)
			// Switch the beam.
			SwitchBeam();
		
		// If the beam is off and the offTime has been reached...
		if(!_renderer.enabled && timer >= offTime)
			// Switch the beam.
			SwitchBeam();
	}
	
	
	void SwitchBeam ()
	{
		// Reset the timer.
		timer = 0f;
		
		// Switch whether the beam and light are on or off.
		_renderer.enabled = !_renderer.enabled;
		GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
	}
}
