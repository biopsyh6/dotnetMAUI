using lab1.Services;
using NbrbAPI.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace lab1;

public partial class Currency_Converter : ContentPage
{
	private IRateService _service;
	private ObservableCollection<string> _currencies = new ObservableCollection<string>();
	public ObservableCollection<string> Currencies
	{
		get { return _currencies; }
		set { _currencies = value; }
	}
	public Currency_Converter(IRateService rateService)
	{
		InitializeComponent();
		_service = rateService;
		datePicker.MaximumDate = DateTime.Now;
		getTodayRates(DateTime.Now);

		BindingContext = this;
	}
	public async Task getTodayRates(DateTime dt)
	{
		IEnumerable<Rate>? rates = await _service.GetRates(dt);
		if(rates != null)
		{
			StringBuilder ratesText = new StringBuilder();
			foreach(Rate rate in rates)
			{
				if (rate.Cur_Abbreviation == "RUB")
					ratesText.AppendLine($"100 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");
				if (rate.Cur_Abbreviation == "EUR")
					ratesText.AppendLine($"1 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");
				if (rate.Cur_Abbreviation == "USD")
					ratesText.AppendLine($"1 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");
				if (rate.Cur_Abbreviation == "CHF")
					ratesText.AppendLine($"1 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");
				if (rate.Cur_Abbreviation == "CNY")
					ratesText.AppendLine($"10 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");
				if (rate.Cur_Abbreviation == "GBP")
					ratesText.AppendLine($"1 {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN");

				if (!_currencies.Contains(rate.Cur_Abbreviation) && (rate.Cur_Abbreviation == "RUB" || rate.Cur_Abbreviation == "EUR"
					|| rate.Cur_Abbreviation == "USD" || rate.Cur_Abbreviation == "CHF" || rate.Cur_Abbreviation == "CNY" ||
                    rate.Cur_Abbreviation == "GBP"))
				{
					_currencies.Add(rate.Cur_Abbreviation);
				}
			}
			EnterRate.Text = ratesText.ToString();
		}
		else
		{
			EnterRate.Text = "Failed to fetch rates from API";
		}
	}
	private async void DateChanged(object sender, DateChangedEventArgs e)
	{
		DateTime selectedDate = e.NewDate;
		await getTodayRates(selectedDate);
	}
}