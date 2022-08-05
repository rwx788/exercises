using Newtonsoft.Json;

namespace maui_counter;

public partial class MainPage : ContentPage
{
	private readonly Counter _counter;
	private int _threads;

	public MainPage()
	{
		InitializeComponent();
		_counter = new Counter(0);
	}

	private void OnIncrementButtonClicked(object sender, EventArgs eventArgs)
	{
		_counter.Value++;
		UpdateCounterValue();
	}

	private void OnResetButtonClicked(object sender, EventArgs eventArgs)
	{
		_counter.Value = 0;
		UpdateCounterValue();
	}

	public void UpdateCounterValue()
	{
		CounterValue.Text = "Counter: " + _counter.Value;
	}

	private void OnThrowHandledException(object sender, EventArgs eventArgs)
	{
		try
		{
			throw new TimeoutException();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void OnThrowUnhandledException(object sender, EventArgs eventArgs)
	{
		throw new TimeoutException();
	}

	private void OnThrowExceptionInExternalCode(object sender, EventArgs eventArgs)
	{
		try
		{
			JsonConvert.DeserializeObject<object>("Invalid JSON");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void OnStartNewThread(object sender, EventArgs eventArgs)
	{
		var thread = new Thread(() =>
		{
			_threads++; Thread.Sleep(100000);
			Console.WriteLine("Thread Finished!");
		})
		{
			Name = $"Xamarin Counter thread {_threads}"
		};
		Console.WriteLine("Thread Started!");
		thread.Start();
	}
}

