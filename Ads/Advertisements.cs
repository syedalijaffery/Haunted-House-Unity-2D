using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisements : MonoBehaviour {

	#if UNITY_IOS
	private string gameId = "1784442";
	#elif UNITY_ANDROID
	private string gameId = "1784443";
	#endif

	void Start ()
	{    

		//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

		//-------------------------------------------------------------------//

	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady("video"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("video", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}
