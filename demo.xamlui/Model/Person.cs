using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo.XamlUi.Model;

public enum Gender
{
    Female,
    Male,
    Other
}

public sealed class Person : INotifyPropertyChanged
{
    private string _name = "Unknown";
    private Gender _gender = Gender.Other;

    public string Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }

    public Gender Gender
    {
        get => _gender;
        set => SetField(ref _gender, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

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