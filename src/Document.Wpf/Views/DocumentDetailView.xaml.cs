namespace Document.Wpf.Views
{
    using System.Windows;
    using System.Windows.Controls;

    using Document.Model.Models;
    using Document.Wpf.ViewModels;

    /// <summary>
    /// Interaction logic for DocumentDetailView.xaml
    /// </summary>
    public partial class DocumentDetailView : UserControl
    {
        public DocumentDetailView()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty DocumentSourceProperty = DependencyProperty.Register("DocumentSource", typeof(DocumentViewModel), typeof(DocumentDetailView), new PropertyMetadata(default(DocumentViewModel)));

        public DocumentViewModel DocumentSource
        {
            get
            {
                return (DocumentViewModel)GetValue(DocumentSourceProperty);
            }
            set
            {
                SetValue(DocumentSourceProperty, value);
            }
        }
    }
}
