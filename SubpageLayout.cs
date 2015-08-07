namespace pocketmodise {
    using PdfSharp.Drawing;

    internal struct SubpageLayout {
		public uint X;
		public uint Y;
	    public Facing Upside;
        public ISuperpageLayout SuperpageLayout;

        public void Transform(XGraphics context, XSize originalSize) {
            var sourceWidth = originalSize.Width;
            var sourceHeight = originalSize.Height;

            var cellWidth = context.PageSize.Width / SuperpageLayout.Columns;
            var cellHeight = context.PageSize.Height / SuperpageLayout.Rows;

            context.TranslateTransform(X * cellWidth, Y * cellHeight);
            context.TranslateTransform(cellWidth / 2, cellHeight / 2);

            context.ScaleTransform(cellWidth, cellHeight);
            context.RotateTransform(Upside.ToAngle());

            context.ScaleTransform(1 / sourceWidth, 1 / sourceHeight);
            context.TranslateTransform(-sourceWidth / 2, -sourceHeight / 2);
        }
    }
}