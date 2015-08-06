namespace pocketmodise {
    using System.Windows;

    /// <summary>
    /// Interaction logic for PocketmodiserWindow.xaml
    /// </summary>
    public partial class PocketmodiserWindow : Window {
        private readonly Converter ConverterBinder;

        public PocketmodiserWindow() {
            InitializeComponent();
            ConverterBinder = new Converter();
            DataContext = ConverterBinder;
        }
    }
}
