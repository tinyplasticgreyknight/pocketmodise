namespace pocketmodise {
    using PdfSharp.Drawing;

    internal struct SubpageLayout {
		public uint X;
		public uint Y;
	    public Facing Upside;
        public ISuperpageLayout SuperpageLayout;

        public void Transform(XGraphics context, XSize originalSize) {
            var cellWidth = context.PageSize.Width / SuperpageLayout.Columns;
            var cellHeight = context.PageSize.Height / SuperpageLayout.Rows;

            context.TranslateTransform(X * cellWidth, Y * cellHeight);
            context.RotateAtTransform(Upside.ToAngle(), new XPoint(cellWidth / 2, cellHeight / 2));
            context.ScaleTransform(cellWidth / originalSize.Width, cellHeight / originalSize.Height);
        }
    }
}