using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo.XamlUi.Model;

public sealed class Context : INotifyPropertyChanged
{
    private ObservableCollection<Person> _persons = new ObservableCollection<Person>();
    private Person? _selectedPerson = null;
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Person> Persons
    {
        get => _persons;
        private set => SetField(ref _persons, value);
    }

    public Person? SelectedPerson
    {
        get => _selectedPerson;
        set => SetField(ref _selectedPerson, value);
    }

    public void RemoveSelected()
    {
        if (SelectedPerson is null)
        {
            return;
        }

        Persons.Remove(SelectedPerson);
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}