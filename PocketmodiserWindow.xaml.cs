namespace pocketmodise {
    /// <summary>
    /// Interaction logic for PocketmodiserWindow.xaml
    /// </summary>
    public partial class PocketmodiserWindow {
        private readonly DocumentBinder documentBinder;

        public PocketmodiserWindow() {
            InitializeComponent();
            documentBinder = new DocumentBinder();
            DataContext = documentBinder;
        }
    }
}
