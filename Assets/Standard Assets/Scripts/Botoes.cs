using UnityEngine;
using System.Collections;

public class Botoes : MonoBehaviour {

	public void Jogar () {
		Application.LoadLevel ("jogar");
	}

	public void Ajuda (){
		Application.LoadLevel ("ajuda");
	}

	public void Voltar (){
		Application.LoadLevel ("intro");
	}

	public void Sair (){
		Application.Quit ();
	}

}
