using System.Windows.Controls;

namespace FilmCataloger.ViewModel
{
    public partial class FilmFormViewModel : UserControl
    {
        public FilmFormViewModel()
        {
            InitializeComponent();
        }
        
        public FilmFormViewModel(long filmId)
        {
            InitializeComponent();
        }
    }
}