using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SaveGameSaver.Core.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public ICommand BackupCommand { get; }
    public ICommand RestoreCommand { get; }

    public MainViewModel()
    {
        BackupCommand = new RelayCommand(Backup);
        RestoreCommand = new RelayCommand(Restore);
    }

    private void Backup()
    {
    }

    private void Restore()
    {
    }
}