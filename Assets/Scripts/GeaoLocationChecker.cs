using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class GeoLocationCheck : MonoBehaviour
{
	[SerializeField] private string _url = "https://uk.wikipedia.org/";
	[SerializeField] private GameObject _mainMenuView;

	private static bool _hasCheckedGeoLocation = false;

	private void Awake()
	{
		if (_hasCheckedGeoLocation)
		{
			Destroy(gameObject);
			return;
		}

		_hasCheckedGeoLocation = true;
		DontDestroyOnLoad(gameObject);
		_mainMenuView.SetActive(false);
		StartCoroutine(CheckGeoLocation());
	}

	private IEnumerator CheckGeoLocation()
	{
		using (UnityWebRequest www = UnityWebRequest.Get("http://ip-api.com/json"))
		{
			yield return www.SendWebRequest();

			if (www.result == UnityWebRequest.Result.Success)
			{
				string jsonResponse = www.downloadHandler.text;
				GeoLocationResponse geoResponse = JsonUtility.FromJson<GeoLocationResponse>(jsonResponse);

				Debug.LogError(geoResponse.countryCode);
				if (geoResponse.countryCode != "UA")
				{
					Application.OpenURL(_url);
					yield break;
				}
			}
			else
			{
				Debug.LogError("Failed to get geo-location data.");
			}

			_mainMenuView.SetActive(true);
		}
	}

	[System.Serializable]
	private class GeoLocationResponse
	{
		public string countryCode;
	}
}