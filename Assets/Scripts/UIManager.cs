using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public TMP_InputField userName;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
		{
			Debug.Log("More Than One Instance Found, Destroying...");
			Destroy(this);
		}
	}

	public void ConnectToServer()
	{
		startMenu.SetActive(false);
		userName.interactable = false;
		Client.instance.ConnectedToServer();
	}
}
