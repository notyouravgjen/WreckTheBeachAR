using UnityEngine;

public class BottomUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnRestartClicked()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
	}
}
