using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DocumentButton : MonoBehaviour {

	public Button button;
	public RectTransform rtrans;
	private string documentId;
	public string DocumentId{
		get{
			return documentId;
		}
		set{
			documentId = value;
			button.GetComponentInChildren<Text>().text = documentId;
		}
	}

	// Use this for initialization
	void Start () {

		button.onClick.AddListener(delegate {
			//Debug.Log("Button " + button.name + " has been clicked!");
			DocumentManager.Document d = DocumentManager.Instance.GetDocument(documentId);
			Debug.Log (d.content);

			SiteInfoUI.Instance.ShowInfo(d);
		});
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
