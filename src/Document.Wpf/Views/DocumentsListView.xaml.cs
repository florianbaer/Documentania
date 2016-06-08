using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Document.Wpf.Views
{
    using System.Collections.ObjectModel;

    using Document.Wpf.ViewModels;

    using Model.Models;

    /// <summary>
    /// Interaction logic for DocumentsListView.xaml
    /// </summary>
    public partial class DocumentsListView : UserControl
    {
        public static readonly DependencyProperty DocumentsProperty = DependencyProperty.Register("Documents", typeof(ObservableCollection<DocumentViewModel>), typeof(DocumentsListView), new PropertyMetadata(default(ObservableCollection<DocumentViewModel>)));
        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register("Selected", typeof(DocumentViewModel), typeof(DocumentsListView), new PropertyMetadata(default(DocumentViewModel)));

        public DocumentsListView()
        {
            InitializeComponent();
        }

        public ObservableCollection<DocumentViewModel> Documents
        {
            get { return (ObservableCollection<DocumentViewModel>) GetValue(DocumentsProperty); }
            set { SetValue(DocumentsProperty, value); }
        }

        public DocumentViewModel Selected
        {
            get { return (DocumentViewModel) GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
    }
}
