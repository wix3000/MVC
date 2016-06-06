using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Controller : MonoBehaviour {

    [SerializeField]
    InputField baseValue, powerValue;

    public Action onPushData;
    public Action<WWW> onModelReturn;

	// Use this for initialization
	void Start () {
	
	}

    public void OnClick_Push() {
        string bv = baseValue.text;
        string pow = powerValue.text;

        baseValue.text = string.Empty;
        powerValue.text = string.Empty;
        if (onPushData != null) onPushData();
        StartCoroutine(PushToModel(bv, pow));
    }

    IEnumerator PushToModel(string value, string power) {
        WWWForm form = new WWWForm();
        form.AddField("value", value);
        form.AddField("power", power);

        WWW www = new WWW("http://XXXXX", form);
        yield return www;

        onModelReturn(www);
    }
}
