using NoMansBlocks.Modules.UI.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Label label = GetComponent<Label>();
        ILabel iLabel = GetComponent<ILabel>();

        Button button = GetComponent<Button>();
        EventSystem.current.SetSelectedGameObject(button.gameObject);

        int four = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
