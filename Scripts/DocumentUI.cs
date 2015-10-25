using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class DocumentUI : MonoBehaviour {

	public DocumentButton documentButtonPref;

	public RectTransform documentPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CategorySelected(string cat){

		int padX = 5;
		int padY = 5;

		int width = (int)documentPanel.rect.width;
		width -= padX * 2;
		int xNum = width / (int)documentButtonPref.rtrans.rect.width;

		DocumentButton[] bs = documentPanel.GetComponentsInChildren<DocumentButton> ();
		foreach (DocumentButton b in bs) {
			Destroy(b.gameObject);
		}

		DocumentManager.Document[] ds = DocumentManager.Instance.GetCategoryDocuments (cat);
		 
		int i = 0;
		foreach(DocumentManager.Document d in ds){
			DocumentButton db = Instantiate (documentButtonPref) as DocumentButton;
			db.transform.SetParent(documentPanel.transform);

			int xOff = padX + (i%xNum) * (int)db.rtrans.rect.width;
			int yOff = padY + (i/xNum) * (int)db.rtrans.rect.height;

			db.rtrans.anchoredPosition = new Vector2(xOff, -yOff);
			db.DocumentId = d.id;

			i++;
		}


	}
}
