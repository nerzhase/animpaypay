using UnityEngine;

public class PointAdder : MonoBehaviour
{
	public int scoreValue = 10;               // The amount added to the player's score

	
	void OnTriggerEnter2D (Collider2D trigger) {
		//	Check the colliding object's tag, and if it is not "Damager", exit this function
		if (trigger.tag != "glas")
			return;

		//Increase the score by the enemy's score value.
		ScoreManager.score += scoreValue;

	}
}