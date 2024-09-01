using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameSceneLoadButton : MonoBehaviour
{
	[SerializeField] private string _sceneName;
	private Button _loadButton;

	
	private void Start()
	{
		_loadButton = GetComponent<Button>();
		_loadButton.onClick.AddListener(OnLoadButtonClick);
	}

	private void OnDestroy()
	{
		_loadButton.onClick.RemoveListener(OnLoadButtonClick);
	}

	private void OnLoadButtonClick()
	{
		if (!string.IsNullOrEmpty(_sceneName))
		{
			SceneManager.LoadScene(_sceneName);
		}
		else
		{
			Debug.LogWarning("Scene name is not assigned.");
		}
	}
}