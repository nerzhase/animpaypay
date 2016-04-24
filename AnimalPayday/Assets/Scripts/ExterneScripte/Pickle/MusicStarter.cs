
using UnityEngine;
using System.Collections;

// Das script wurde zum teil von Denis gschrieben und wurde uns von Laura gegeben, alles verstehe ich leider nicht
public class MusicStarter : MonoBehaviour {
	private AudioSource audioSource;


	AudioSource audio;
	GameObject[] musicObject;
	
	// Use this for initialization
	void Start () {
		
		audio = GetComponent<AudioSource>();
		audioSource = gameObject.GetComponent<AudioSource> ();
		
		musicObject = GameObject.FindGameObjectsWithTag ("GameMusic");
		if (musicObject.Length == 1 ) {
			audio.Play ();
		} else {
			for(int i = 1; i < musicObject.Length; i++){
				Destroy(musicObject[i]);
			}
			
		}
		
		
	}
	
	// Update is called once per frame
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
	
}