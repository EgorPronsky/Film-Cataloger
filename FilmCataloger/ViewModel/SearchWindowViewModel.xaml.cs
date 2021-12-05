using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FilmCataloger.ViewModel
{
    public partial class SearchWindowViewModel : Window
    {
        public SearchWindowViewModel()
        {
            InitializeComponent();
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            HashSet<string> keyWordList = new HashSet<string>();
            foreach (UIElement keyWord in KeyWords.Children)
            {
                keyWordList.Add(((TextBox) keyWord).Text);
            }
            MainWindowViewModel.ShowSearchResults(keyWordList);
        }

        private void AddKeyWordFieldButton_OnClick(object sender, RoutedEventArgs e)
        {
            KeyWords.Children.Add(new TextBox()
            {
                FontSize = 14,
                Margin = new Thickness(0,5,0,5),
                Width = 300,
                Height = 30
            });
        }
    }
}