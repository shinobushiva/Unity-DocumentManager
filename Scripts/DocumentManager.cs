using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class DocumentManager : SingletonMonoBehaviour<DocumentManager> {

	[System.Serializable]
	public class Document{
		public string id;
		public string category;
		public string text;
		public string content;
	}

	public Document[] documents;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public DocumentManager.Document[] GetCategoryDocuments(string cat){
		return documents.Where(d => d.id.Contains(cat+"-")).ToArray();
	}
	public DocumentManager.Document GetDocument(string id){
		return documents.Where (d => d.id.Equals (id)).Single ();
	}
}

