using Avalonia;
using Avalonia.Controls;
using Demo.XamlUi.Model;

namespace Demo.XamlUi;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new Context
        {
            Persons =
            {
                new Person { Name = "John", Gender = Gender.Male },
                new Person { Name = "Mary", Gender = Gender.Female },
                new Person { Name = "Jane", Gender = Gender.Female },
            }
        };

        AddBtn.Click += (sender, e) =>
        {
            var context = DataContext as Context;
            if (context == null) return;

            context.Persons.Add(new Person { Name = "New Person", Gender = Gender.Other });
        };
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.AttachDevTools();
    }
}