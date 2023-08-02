using UnityEngine;

public class TitleMenuManager : MonoBehaviour {

	public void OnPlayClicked()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene("BeachScene");
    }
}
