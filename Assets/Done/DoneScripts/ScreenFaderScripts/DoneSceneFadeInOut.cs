using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoneSceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;			// Speed that the screen fades to and from black.
	
	
	private GUITexture _guiTexture;			// Reference to the GUITexture.
	private bool sceneStarting = true;		// Whether or not the scene is still fading in.
	
	
	void Awake ()
	{
		// Setting up the references.
		_guiTexture = GetComponent<GUITexture>();

		// Set the texture so that it is the the size of the screen and covers it.
		_guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		_guiTexture.color = Color.Lerp(_guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		_guiTexture.color = Color.Lerp(_guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(_guiTexture.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			_guiTexture.color = Color.clear;
			_guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		_guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(_guiTexture.color.a >= 0.95f)
			// ... reload the level.
			SceneManager.LoadScene(0);
	
	}
}
