#pragma strict

var Opponent_Left_Button : UnityEngine.UI.Button;
var Opponent_Right_Button : UnityEngine.UI.Button;
var Player_Left_Button : UnityEngine.UI.Button;
var Player_Right_Button : UnityEngine.UI.Button;
var Current_Button : UnityEngine.UI.Button;

var Split_Button : GameObject;

var Turn_Status : String;
var AI_Turn : UnityEngine.UI.Text;
var Player_Turn : UnityEngine.UI.Text;

function Start () {
	Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = "2";
	Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = "2";
	Player_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = "2";
	Player_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = "2";
	Split_Button.SetActive(false);
	Turn_Status = "Player";
}

function Update () {
	Opponent_Left_Button.colors.normalColor = Color.white;
	Opponent_Right_Button.colors.normalColor = Color.white;
	Player_Left_Button.colors.normalColor = Color.white;
	Player_Right_Button.colors.normalColor = Color.white;
	if (Turn_Status == "Player") {
		AI_Turn.text = "";
		Player_Turn.text = "Player's Turn";
	}else {
		AI_Turn.text = "A.I.'s Turn";
		Player_Turn.text = "";
		AI();
	}
	if (int.Parse(Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) >= 5) {
		Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) - 5).ToString();
	}
	if (int.Parse(Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) >= 5) {
		Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) - 5).ToString();
	}
	if (int.Parse(Player_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) >= 5) {
		Player_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Player_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) - 5).ToString();
	}
	if (int.Parse(Player_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) >= 5) {
		Player_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Player_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) - 5).ToString();
	}
	if (Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0" && Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0") {
		AI_Turn.text = "PLAYER WINS";
		Player_Turn.text = "PLAYER WINS";
		Turn_Status = "GameOver";
	}else if (Player_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0" && Player_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0") {
		AI_Turn.text = "AI WINS";
		Player_Turn.text = "AI WINS";
		Turn_Status = "GameOver";
	}
	Current_Button.colors.normalColor = Color.red;
}

function Switch_1 () {
	if (Turn_Status == "Player") {
		if (Current_Button == Player_Left_Button || Current_Button == Player_Right_Button) {
			Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Opponent_Left_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) + int.Parse(Current_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text)).ToString();
			Turn_Status = "AI";
		}
		Current_Button = Opponent_Left_Button;
		Split_Button.SetActive(false);
	}
}

function Switch_2 () {
	if (Turn_Status == "Player") {
		if (Current_Button == Player_Left_Button || Current_Button == Player_Right_Button) {
			Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Opponent_Right_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text) + int.Parse(Current_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text)).ToString();
			Turn_Status = "AI";
		}
		Current_Button = Opponent_Right_Button;
		Split_Button.SetActive(false);
	}
}

function Switch_3 () {
	if (Turn_Status == "Player") {
		Current_Button = Player_Left_Button;
		//Split_Button.SetActive(true);
	}
}

function Switch_4 () {
	if (Turn_Status == "Player") {
		Current_Button = Player_Right_Button;
		//Split_Button.SetActive(true);
	}
}

function AI () {
	if (Turn_Status == "AI") {
		var Selecter : int = Random.Range(1, 3);
		if (Selecter == 1) {
			Current_Button = Opponent_Left_Button;
		}else if (Selecter == 2) {
			Current_Button = Opponent_Right_Button;
		}
		while (Current_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0") {
			Selecter = Random.Range(1, 3);
			if (Selecter == 1) {
				Current_Button = Opponent_Left_Button;
			}else if (Selecter == 2) {
				Current_Button = Opponent_Right_Button;
			}
		}
		//yield WaitForSeconds(Random.Range(2.0f, 4.0f));
		var Target : UnityEngine.UI.Button;
		Selecter = Random.Range(1, 3);
		if (Selecter == 1) {
			Target = Player_Left_Button;
		}else if (Selecter == 2) {
			Target = Player_Right_Button;
		}
		while (Target.GetComponentInChildren.<UnityEngine.UI.Text>().text == "0") {
			Selecter = Random.Range(1, 3);
			if (Selecter == 1) {
				Target = Player_Left_Button;
			}else if (Selecter == 2) {
				Target = Player_Right_Button;
			}
		}
		if (Turn_Status == "AI") {
			Debug.Log(int.Parse(Current_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text));
			Target.GetComponentInChildren.<UnityEngine.UI.Text>().text = (int.Parse(Target.GetComponentInChildren.<UnityEngine.UI.Text>().text) + int.Parse(Current_Button.GetComponentInChildren.<UnityEngine.UI.Text>().text)).ToString();
			Current_Button = Target;
			Turn_Status = "Player";
		}
	}
}