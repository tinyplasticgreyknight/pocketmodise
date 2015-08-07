namespace pocketmodise {
    using PdfSharp.Drawing;

    internal struct Subpage {
        private SubpageLayout layout;
        private readonly XPdfForm form;
        private readonly int sourcePageIndex;

        public Subpage(XPdfForm form, uint sourcePageIndex, SubpageLayout layout) {
            this.form = form;
            this.sourcePageIndex = (int)sourcePageIndex;
            this.layout = layout;
        }

        public void DrawTo(XGraphics context) {
            var state = context.Save();
            layout.Transform(context, form.Size);
            form.PageIndex = sourcePageIndex;
            context.DrawImage(form, 0, 0);
            context.Restore(state);
        }
    }
}