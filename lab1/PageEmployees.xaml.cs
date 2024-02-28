using lab1.Entities;
using lab1.Services;

namespace lab1;

public partial class PageEmployees : ContentPage
{
	private List<JobResponsibilities> _responsibilities;
	private List<Employees> _employees;
	private IDbService _dbservice;
	public PageEmployees(IDbService dbService)
	{

        InitializeComponent();
		string databasePath = "Database.db";
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, databasePath);
		_dbservice = dbService;// = new SQLiteService(dbPath);
		LoadData();
	}
	private void LoadData()
	{ 
		_responsibilities = _dbservice.GetAllResponsibilities().ToList();
		groupPicker.ItemsSource = _responsibilities;
	}
	private void OnGroupSelectedIndexChanged(object sender, EventArgs e)
	{
		var selectedResponsibility = groupPicker.SelectedItem as JobResponsibilities;
		if(selectedResponsibility != null)
		{
			_employees = _dbservice.GetEmployeesOfJob(selectedResponsibility.Id).ToList();
			collectionView.ItemsSource = _employees;
		}
	}

}