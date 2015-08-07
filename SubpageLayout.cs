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

            context.ScaleTransform(cellWidth, cellHeight);

            context.TranslateTransform(0.5, 0.5);
            context.RotateTransform(Upside.ToAngle());
            context.TranslateTransform(-0.5, -0.5);

            context.ScaleTransform(1 / sourceWidth, 1 / sourceHeight);
        }
    }
}