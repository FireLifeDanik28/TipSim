namespace M8;

public partial class BILL : ContentPage
{
	public BILL()
	{
		InitializeComponent();
	}
	float bill = 0.00f;
	float tipPerc = 0.00f;
    float tip = 0.00f;
	float split = 1;
	float total = 0.00f;
    private void textChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
            bill = float.Parse(enterBill.Text);
            Total();
        }
		catch {}
    }
    private void OnFirstButtonClicked(object sender, EventArgs e)
    {
        tipPerc = 0.10f;
        sliderTip.Value = 10;
        Total();
    }
    private void OnSecondButtonClicked(object sender, EventArgs e)
    {
        tipPerc = 0.15f;
        sliderTip.Value = 15;
        Total();
    }
    private void OnThirdButtonClicked(object sender, EventArgs e)
    {
        tipPerc = 0.20f;
        sliderTip.Value = 20;
        Total();
    }
    private void sliderValue(object sender, ValueChangedEventArgs e)
    {
        tipPerc = (float)Math.Round(sliderTip.Value/100, 2);
        sliderTipView.Text = ($"Tip: {(float)Math.Round(tipPerc*100, 2)}%");
        Total();
    }
    public void Total()
    {
        bill = (float)Math.Round(bill, 2);
        tip = bill * tipPerc;
        tip = (float)Math.Round(tip, 2);
        partTip.Text = ($"${tip}");
        partBill.Text = ($"${bill}");
        total = (bill + tip) / split;
        totalBill.Text = ($"${(float)Math.Round(total, 2)}");
    }
    private void OnPlusButtonClicked(object sender, EventArgs e)
    {
        split++;
        sub.Text = ($"{split}");
        Total();
    }
    private void OnMinusButtonClicked(object sender, EventArgs e)
    {
        if (split > 1) {
            split = split - 1;
            sub.Text = ($"{split}");
            Total();
        }
    }



}