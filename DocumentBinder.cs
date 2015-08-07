namespace pocketmodise {
    using System.Windows.Input;
    using PdfSharp;

    internal class DocumentBinder {
        public NullaryCommand OpenInputCommand { get; set; }
        public NullaryCommand RenderCommand { get; set; }
        public NullaryCommand WriteOutputCommand { get; set; }

        private PocketModDocument document;

        public DocumentBinder() {
            OpenInputCommand = new NullaryCommand(ReadInputFile, CanSelectInputFile);
            RenderCommand = new NullaryCommand(RenderDocument, CanRender);
            WriteOutputCommand = new NullaryCommand(WriteOutputFile, CanSave);
        }

        private static bool CanSelectInputFile() {
            return true;
        }

        private bool CanRender() {
            return document != null;
        }

        private bool CanSave() {
            return document != null && document.IsRendered;
        }

        private void ReadInputFile() {
            document = new PocketModDocument(DialogService.ChooseFileToOpen());
            RenderCommand.RaiseCanExecuteChanged();
            WriteOutputCommand.RaiseCanExecuteChanged();
        }

        private void RenderDocument() {
            document.Render(PageSize.A4);
            WriteOutputCommand.RaiseCanExecuteChanged();
        }

        private void WriteOutputFile() {
            document.WriteToFile(DialogService.ChooseFileToSave());
        }
    }
}
