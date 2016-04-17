using UnityEngine;
using System.Collections;

// Damit arbeite ich noch herum - ignorieren

public class NewLevelwechsel: MonoBehaviour {

	public string nextLevel;		// nächstes Level angeben
	public int TargetScore;			// zu übertreffender Score
	public float loadingtime;		// dauer bis nächstes lvl	

	private int scoreValue;			// erreichter Score

			
		void OnTriggerEnter2D (Collider2D trigger) {
			scoreValue = ScoreManager.score;

			if (trigger.tag != "valuable")
			return;
			
//			print ("its in");


			if (scoreValue >= TargetScore) {

//			print (scoreValue);
//			print (TargetScore);
			GetComponent<ParticleSystem>().Play();
			Winningscreen ();
			}
			
	}

	void Winningscreen () {

		StartCoroutine (loadingLevel (loadingtime));

	}

	IEnumerator loadingLevel(float waitTime) {

			yield return new WaitForSeconds(waitTime);
//			print ("loading next level");
			Application.LoadLevel(nextLevel);
		}
}
