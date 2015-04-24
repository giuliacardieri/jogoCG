using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	GameObject player;
	public float velocidade = 22;
	public float tempo = 0;
	
	// Use this for initialization
	void Start () {
		rigidbody.freezeRotation = true;
		player = null;
	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
		if (tempo >= 15) {
			tempo = 0;
			transform.Rotate(0,180,0);
		}
		if (player == null) {
			transform.Translate (new Vector3 (0, 0, velocidade * Time.deltaTime));
			Collider [] objetos = Physics.OverlapSphere(transform.position, 75f); // quando o inimigo estiver perto o suficiente ele vai correr atrás do player.
			for(int i=0; i<objetos.Length; i++){
				if(objetos[i].tag == "Player"){
					player = objetos[i].gameObject;
				}
			}
		}
		else{
			transform.LookAt (player.transform); // faz o inimigo "achar" o player
			transform.Translate (0,0, velocidade * Time.deltaTime); // agora o inimigo vai tentar pegar o player.
		}
	}

	void OnCollisionEnter(Collision obj){ //quando o player está parado mas o inimigo colide com ele.
		if (obj.transform.tag == "Player") {
				Destroy(obj.gameObject); //destroi o player
				Application.LoadLevel("dead");  
			} 
	}
}
