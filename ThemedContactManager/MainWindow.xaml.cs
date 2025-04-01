using System;
using System.Windows;

namespace ThemedContactManager
{
    public partial class MainWindow : Window
    {
        private bool isDark = false; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            var appResources = Application.Current.Resources.MergedDictionaries;
            appResources.Clear();

            string themePath = isDark ? "Themes/Light.xaml" : "Themes/Dark.xaml";
            appResources.Add(new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) });
            appResources.Add(new ResourceDictionary { Source = new Uri("Themes/CustomStyles.xaml", UriKind.Relative) });


            ThemeToggleButton.Content = isDark ? "🌙 Dark Mode" : "☀️ Light Mode";

            isDark = !isDark;
        }

    }
}
