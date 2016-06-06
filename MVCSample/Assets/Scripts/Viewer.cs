using UnityEngine;
using System.Collections;

public class Viewer : MonoBehaviour {

    [SerializeField]
    Controller controller;

    [SerializeField]
    GameObject loading, num;

	// Use this for initialization
	void Start () {
        controller.onPushData += OnPushData;
        controller.onModelReturn += OnModelReturn;
	}
	
    void OnPushData() {
        loading.SetActive(true);
        num.SetActive(false);
    }

    void OnModelReturn(WWW www) {
        string value = (www.error == null) ? www.text : "[ERROR]";

        num.GetComponent<UnityEngine.UI.Text>().text = value;
        num.SetActive(true);
        loading.SetActive(false);
    }

}
