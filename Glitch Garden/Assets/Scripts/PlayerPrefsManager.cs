﻿using UnityEngine;
using System.Collections;


// This Script will allow the user to change settings
public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY    = "difficulty";
	const string LEVEL_KEY         = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume > 0f && volume < 100f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume has gone out of range.");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	// This will give the user settings for which levels they can play.
	public static void UnlockLevel (int level){
		if (level < Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true
		} else {
			Debug.LogError("Can not unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= Application.levelCount - 1){ 
			return isLevelUnlocked;
		} else {
			Debug.LogError("An error for the level");
			return false;
		}
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty > 0.9f && difficulty <= 3.1f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficult out of range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

}
