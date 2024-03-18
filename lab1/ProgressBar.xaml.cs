using System.Transactions;
using System.Threading;
using System.Threading.Tasks;
using System.Security.AccessControl;
using Microsoft.Maui.Controls;
using System.Diagnostics;
namespace lab1;

public partial class ProgressBar : ContentPage
{
	private CancellationTokenSource cancellationTokenSource; 
	bool cancelFlag = false;
	public ProgressBar()
	{
		InitializeComponent();
	}
	private async void ClickStart(object sender, EventArgs e)
	{
		BtnStart.IsEnabled = false;
		cancelFlag = true;
		ProgressBar1.Progress = 0;
		Print.Text = "Вычисление";
		cancellationTokenSource = new CancellationTokenSource();
		Debug.WriteLine($"---------------------> Enter calculation {Thread.CurrentThread.ManagedThreadId}");
        try
		{
			double result = await Task.Run( ()=> CalculateIntegralAsync(cancellationTokenSource.Token));
			Print.Text = $"Результат: {result}";
		}
		catch (OperationCanceledException)
		{
			Print.Text = "Задание отменено";
		}
		finally
		{
			BtnStart.IsEnabled = true;
		}
	}
	private void ClickCancel(object sender, EventArgs e)
	{
		BtnStart.IsEnabled = true;
		if (cancelFlag) cancellationTokenSource.Cancel();
		else { }
	}
	private async Task<double> CalculateIntegralAsync(CancellationToken cancellationToken)
	{
		Debug.WriteLine($"-------------------> Inside calculation {Thread.CurrentThread.ManagedThreadId}");
        double step = 0.01;
		double start = 0;
		double end = 1;
		double progress = 0;
		int iterations = (int)((end - start) / step);
		int delayIterations = 1000;
		double integral = 0;
		for (int i = 0; i < iterations; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			integral += Math.Sin(start + i * step) * step;
			if(i % delayIterations == 0)
			{
				await Task.Delay(1);
			}
			await MainThread.InvokeOnMainThreadAsync(() =>
			{
                Debug.WriteLine($"---------------> Changing progressBar {Thread.CurrentThread.ManagedThreadId}");
                progress = (double)i / iterations;
				ProgressBar1.Progress = progress;
				LabelProgressBar.Text = $"{progress * 100:F1}%";
			});
            Debug.WriteLine($"---------------> Outside changing progressBar {Thread.CurrentThread.ManagedThreadId}");
        }
		return integral;
	}
}