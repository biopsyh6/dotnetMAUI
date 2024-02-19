using Microsoft.Maui.Graphics.Text;

namespace lab1;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
		InitializeComponent();
	}
	bool ClearAfterOperationFlag = false;
	bool DeleteFlag = true;
	bool PointFlag = true;
	bool OperationFlag = false;
	double memory = 0;
	//double secondMemory = 0;
	string buttonText = "";
	private void ClickNumber(object sender, EventArgs e)
	{
		if (DeleteFlag == false || OperationFlag || ClearAfterOperationFlag)
		{
			Enter.Text = "";
			DeleteFlag = true;
			PointFlag = true;
			ClearAfterOperationFlag = false;
			OperationFlag = false;
		}
		if (Enter.Text.Length == 13)
		{
			Enter.Text = "Error";
			DeleteFlag = false;
		}
		else
		{
			Button button = (Button)sender;
			string buttonText = button.CommandParameter.ToString()!;
			if (Enter.Text == "0" || Enter.Text == "-0")
			{
				Enter.Text = "";
			}
			Enter.Text += buttonText;
		}
	}
    private void ClickReset(object sender, EventArgs e)
    {
        Enter.Text = "0";
		DeleteFlag = true;
		PointFlag = true;
		memory = 0;
		ClearAfterOperationFlag = false;
		OperationFlag = false;
		buttonText = "";
    }
	private void ClickBackspace(object sender, EventArgs e)
	{
		if (Enter.Text.Length == 1 || Enter.Text == "Error" || !DeleteFlag)
		{
			Enter.Text = "0";
		}
		else
		{
			if (Enter.Text[Enter.Text.Length-1] == '.')
			{
				PointFlag = true;
			}
			Enter.Text = Enter.Text.Remove(Enter.Text.Length - 1);
			DeleteFlag = true;
		}
	}
	private void ClickLog(object sender, EventArgs e)
	{
		if(double.TryParse(Enter.Text, out double Number) && Number > 0 && DeleteFlag)
		{
			String Res = Math.Log(Number).ToString();
			if (Res.Length > 13)
			{
				Enter.Text = Res.Substring(0, 13);
			}
			else Enter.Text = Res;
		}
		else
		{
			Enter.Text = "Error";
			DeleteFlag = false;
		}
	}
	private void ClickDivideX(object sender, EventArgs e)
	{
		if(double.TryParse(Enter.Text, out double Number) && Number != 0 && DeleteFlag)
		{
			String Res = (1 / Number).ToString();
			if(Res.Length > 13)
			{
				Enter.Text = Res.Substring(0, 13);
			}
			else Enter.Text = Res;
		}
		else
		{
			Enter.Text = "Error";
			DeleteFlag = false;
		}
	}
	private void ClickPow(object sender, EventArgs e)
	{
		if (double.TryParse(Enter.Text, out double Number) && DeleteFlag)
		{
			String Res = (Math.Pow(Number, 2)).ToString();
			if(Res.Length > 13)
			{
				Enter.Text = Res.Substring(0, 13);
				DeleteFlag = false;
			}
			else Enter.Text = Res;
		}
		else
		{
			Enter.Text = "Error";
			DeleteFlag = false;
		}
	}
	private void ClickSqrt(object sender, EventArgs e)
	{
		if (double.TryParse(Enter.Text, out double Number) && Number >= 0 && DeleteFlag)
		{
			String Res = (Math.Sqrt(Number)).ToString();
			if(Res.Length > 13)
			{
				Enter.Text = Res.Substring(0, 13);
				PointFlag = true;
			}
			else Enter.Text = Res;
		}
		else
		{
			Enter.Text = "Error";
			DeleteFlag = false;
		}
	}
	private void ClickPoint(object sender, EventArgs e)
	{
		if (PointFlag)
		{
			Enter.Text += ",";
			PointFlag = false;
		}
		else
		{ }
	}
	private void ClickPlusMinus(object sender, EventArgs e)
	{
		if (Enter.Text[0] == '-') Enter.Text = Enter.Text.Remove(0, 1);
		else Enter.Text = Enter.Text.Insert(0, "-");
	}
	private void ClickOperator(object sender, EventArgs e)
	{
		double.TryParse(Enter.Text, out double Number);
		memory = Number;
        Button button = (Button)sender;
        buttonText = button.CommandParameter.ToString()!;
		OperationFlag = true;
	}
	private void ClickEqual(object sender, EventArgs e)
	{
		double.TryParse(Enter.Text, out double Number);
		Enter.Text = "";
		if(buttonText == "/")
		{	if (Number == 0)
			{
				Enter.Text = "Error";
				DeleteFlag = false;
				OperationFlag = false;
			}
			else
			{
				String Res = (memory / Number).ToString();
				if (Res.Length > 13)
				{
					Enter.Text = Res.Substring(0, 13);
				}
				else Enter.Text = Res;
                OperationFlag = false;
				ClearAfterOperationFlag = true;
			}
		}
		else if(buttonText == "*")
		{
			String Res = (memory * Number).ToString();
			if(Res.Length > 13)
			{
				Enter.Text = Res.Substring(0, 13);
			}
			else Enter.Text = Res;
            OperationFlag = false;
			ClearAfterOperationFlag = true;
        }
        else if (buttonText == "+")
        {
            String Res = (memory + Number).ToString();
            if (Res.Length > 13)
            {
                Enter.Text = Res.Substring(0, 13);
            }
            else Enter.Text = Res;
            OperationFlag = false;
            ClearAfterOperationFlag = true;
        }
        else if (buttonText == "-")
        {
            String Res = (memory - Number).ToString();
            if (Res.Length > 13)
            {
                Enter.Text = Res.Substring(0, 13);
            }
            else Enter.Text = Res;
            OperationFlag = false;
            ClearAfterOperationFlag = true;
        }
    }

}