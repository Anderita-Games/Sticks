using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameMaster : MonoBehaviour
{
    public UnityEngine.UI.Button Opponent_Left_Button;
    public UnityEngine.UI.Button Opponent_Right_Button;
    public UnityEngine.UI.Button Player_Left_Button;
    public UnityEngine.UI.Button Player_Right_Button;
    public UnityEngine.UI.Button Current_Button;
    public GameObject Split_Button;
    public string Turn_Status;
    public UnityEngine.UI.Text AI_Turn;
    public UnityEngine.UI.Text Player_Turn;
    public virtual void Start()
    {
        this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";
        this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";
        this.Player_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";
        this.Player_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";
        this.Split_Button.SetActive(false);
        this.Turn_Status = "Player";
    }

    public virtual void Update()
    {

        {
            Color _1 = Color.white;
            UnityEngine.UI.ColorBlock _2 = this.Opponent_Left_Button.colors;
            _2.normalColor = _1;
            this.Opponent_Left_Button.colors = _2;
        }

        {
            Color _3 = Color.white;
            UnityEngine.UI.ColorBlock _4 = this.Opponent_Right_Button.colors;
            _4.normalColor = _3;
            this.Opponent_Right_Button.colors = _4;
        }

        {
            Color _5 = Color.white;
            UnityEngine.UI.ColorBlock _6 = this.Player_Left_Button.colors;
            _6.normalColor = _5;
            this.Player_Left_Button.colors = _6;
        }

        {
            Color _7 = Color.white;
            UnityEngine.UI.ColorBlock _8 = this.Player_Right_Button.colors;
            _8.normalColor = _7;
            this.Player_Right_Button.colors = _8;
        }
        if (this.Turn_Status == "Player")
        {
            this.AI_Turn.text = "";
            this.Player_Turn.text = "Player's Turn";
        }
        else
        {
            this.AI_Turn.text = "A.I.'s Turn";
            this.Player_Turn.text = "";
            this.AI();
        }
        if (int.Parse(this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) >= 5)
        {
            this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) - 5).ToString();
        }
        if (int.Parse(this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) >= 5)
        {
            this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) - 5).ToString();
        }
        if (int.Parse(this.Player_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) >= 5)
        {
            this.Player_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Player_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) - 5).ToString();
        }
        if (int.Parse(this.Player_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) >= 5)
        {
            this.Player_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Player_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) - 5).ToString();
        }
        if ((this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text == "0") && (this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text == "0"))
        {
            this.AI_Turn.text = "PLAYER WINS";
            this.Player_Turn.text = "PLAYER WINS";
            this.Turn_Status = "GameOver";
        }
        else
        {
            if ((this.Player_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text == "0") && (this.Player_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text == "0"))
            {
                this.AI_Turn.text = "AI WINS";
                this.Player_Turn.text = "AI WINS";
                this.Turn_Status = "GameOver";
            }
        }

        {
            Color _9 = Color.red;
            UnityEngine.UI.ColorBlock _10 = this.Current_Button.colors;
            _10.normalColor = _9;
            this.Current_Button.colors = _10;
        }
    }

    public virtual void Switch_1()
    {
        if (this.Turn_Status == "Player")
        {
            if ((this.Current_Button == this.Player_Left_Button) || (this.Current_Button == this.Player_Right_Button))
            {
                this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Opponent_Left_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) + int.Parse(this.Current_Button.GetComponentInChildren<UnityEngine.UI.Text>().text)).ToString();
                this.Turn_Status = "AI";
            }
            this.Current_Button = this.Opponent_Left_Button;
            this.Split_Button.SetActive(false);
        }
    }

    public virtual void Switch_2()
    {
        if (this.Turn_Status == "Player")
        {
            if ((this.Current_Button == this.Player_Left_Button) || (this.Current_Button == this.Player_Right_Button))
            {
                this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(this.Opponent_Right_Button.GetComponentInChildren<UnityEngine.UI.Text>().text) + int.Parse(this.Current_Button.GetComponentInChildren<UnityEngine.UI.Text>().text)).ToString();
                this.Turn_Status = "AI";
            }
            this.Current_Button = this.Opponent_Right_Button;
            this.Split_Button.SetActive(false);
        }
    }

    public virtual void Switch_3()//Split_Button.SetActive(true);
    {
        if (this.Turn_Status == "Player")
        {
            this.Current_Button = this.Player_Left_Button;
        }
    }

    public virtual void Switch_4()//Split_Button.SetActive(true);
    {
        if (this.Turn_Status == "Player")
        {
            this.Current_Button = this.Player_Right_Button;
        }
    }

    public virtual void AI()
    {
        if (this.Turn_Status == "AI")
        {
            int Selecter = Random.Range(1, 3);
            if (Selecter == 1)
            {
                this.Current_Button = this.Opponent_Left_Button;
            }
            else
            {
                if (Selecter == 2)
                {
                    this.Current_Button = this.Opponent_Right_Button;
                }
            }
            while (this.Current_Button.GetComponentInChildren<UnityEngine.UI.Text>().text == "0")
            {
                Selecter = Random.Range(1, 3);
                if (Selecter == 1)
                {
                    this.Current_Button = this.Opponent_Left_Button;
                }
                else
                {
                    if (Selecter == 2)
                    {
                        this.Current_Button = this.Opponent_Right_Button;
                    }
                }
            }
            //yield WaitForSeconds(Random.Range(2.0f, 4.0f));
            UnityEngine.UI.Button Target = null;
            Selecter = Random.Range(1, 3);
            if (Selecter == 1)
            {
                Target = this.Player_Left_Button;
            }
            else
            {
                if (Selecter == 2)
                {
                    Target = this.Player_Right_Button;
                }
            }
            while (Target.GetComponentInChildren<UnityEngine.UI.Text>().text == "0")
            {
                Selecter = Random.Range(1, 3);
                if (Selecter == 1)
                {
                    Target = this.Player_Left_Button;
                }
                else
                {
                    if (Selecter == 2)
                    {
                        Target = this.Player_Right_Button;
                    }
                }
            }
            if (this.Turn_Status == "AI")
            {
                Debug.Log(int.Parse(this.Current_Button.GetComponentInChildren<UnityEngine.UI.Text>().text));
                Target.GetComponentInChildren<UnityEngine.UI.Text>().text = (int.Parse(Target.GetComponentInChildren<UnityEngine.UI.Text>().text) + int.Parse(this.Current_Button.GetComponentInChildren<UnityEngine.UI.Text>().text)).ToString();
                this.Current_Button = Target;
                this.Turn_Status = "Player";
            }
        }
    }

}