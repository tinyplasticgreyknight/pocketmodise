namespace pocketmodise {
    using System.Collections.Generic;
    using PdfSharp;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    internal class PocketModDocument {
        private readonly IList<Superpage> superpages;
        private PdfDocument renderOutput;

        public PocketModDocument(string fileName) {
            superpages = Superpage.Layout(XPdfForm.FromFile(fileName), new Superpage4x2());
        }

        public bool IsRendered { get; private set; }

        public void WriteToFile(string outputFileName) {
            SaveOutputFile(outputFileName);
        }

        public void Render(PageSize size) {
            CreateFreshDocument();
            DrawPages(size);
            IsRendered = true;
        }

        private void CreateFreshDocument() {
            renderOutput = new PdfDocument { PageLayout = PdfPageLayout.SinglePage };
        }

        private void DrawPages(PageSize size) {
            foreach (var superpage in superpages) {
                DrawPage(size, superpage);
            }
        }

        private void DrawPage(PageSize size, Superpage superpage) {
            var documentPage = renderOutput.AddPage();
            documentPage.Size = size;
            documentPage.Orientation = PageOrientation.Landscape;
            superpage.DrawTo(XGraphics.FromPdfPage(documentPage));
        }

        private void SaveOutputFile(string outputFileName) {
            renderOutput.Save(outputFileName);
        }
    }
}
