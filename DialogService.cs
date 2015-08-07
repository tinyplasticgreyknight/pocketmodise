namespace pocketmodise {
    using System.IO;
    using Microsoft.Win32;

    internal class DialogService {
        private const string StandardFilter = "PDF files|*.pdf|All files|*.*";

        public static string ChooseFileToOpen() {
            var dialog = new OpenFileDialog { Filter = StandardFilter };
            if (dialog.ShowDialog() != true) {
                throw new IOException();
            }

            return dialog.FileName;
        }

        public static string ChooseFileToSave() {
            var dialog = new SaveFileDialog { Filter = StandardFilter };
            if (dialog.ShowDialog() != true) {
                throw new IOException();
            }

            return dialog.FileName;
        }
    }
}