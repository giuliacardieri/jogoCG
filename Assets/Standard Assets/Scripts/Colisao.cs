using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Colisao : MonoBehaviour {

	int artefatosCounter = 0;
	bool colidiu = false;
	 float tempoColisao = 0;
	
	public AudioClip artefatoSom;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tempoColisao += Time.deltaTime;
		if (colidiu && tempoColisao >= 3)
			colidiu = false;
	}

	void OnControllerColliderHit(ControllerColliderHit obj){   // quando o personagem colide com alguma coisa;
		if (obj.transform.tag == "Inimigo") { // se colidir com o inimigo
			Destroy(gameObject); // destroi o player se ele colidir com o inimigo.	
			Application.LoadLevel("dead");  
		}
		if (obj.transform.tag == "Artefato") { // se colidir com algum artefato
			if (!colidiu){ // impede erros em caso de colisões duplas
				tempoColisao = 0;
				Destroy(obj.gameObject); // destroi o artefato porque ele foi armazenado.
				artefatosCounter++; // incrementa o contador de artefatos
				GameObject.Find("Artefatos").GetComponent<Text> ().text = (artefatosCounter.ToString())+"/5"; // muda o número de artefatos encontrados na tela.
				GetComponent<AudioSource>().PlayOneShot(artefatoSom);
				if (artefatosCounter == 5)
					Application.LoadLevel("win"); 
			}
			colidiu = true;
		}
	}
}
