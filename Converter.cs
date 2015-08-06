namespace pocketmodise {
    using System.Windows.Input;

    public class Converter {
        public ICommand OpenInputCommand { get; set; }
        public ICommand RenderOutputCommand { get; set; }
    }
}
