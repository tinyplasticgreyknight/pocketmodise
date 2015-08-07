namespace pocketmodise {
    using System;
    using System.Collections.Generic;
    using PdfSharp.Drawing;

    internal class Superpage {
        private readonly IList<Subpage> subpages;
        private readonly ISuperpageLayout layout;

        public Superpage(XPdfForm form, uint startPage, uint numPages, ISuperpageLayout layout) {
            subpages = new List<Subpage>();
            for (uint i = 0; i < numPages; i++) {
                subpages.Add(new Subpage(form, startPage + i, layout.GetSubpageLayout(i)));
            }

            this.layout = layout;
        }

        public static IList<Superpage> Layout(XPdfForm form, ISuperpageLayout layout) {
            var superpages = new List<Superpage>();
            for (uint start = 0; start < form.PageCount; start += layout.Count) {
                var numPages = (uint)Math.Min(layout.Count, form.PageCount - start);
                superpages.Add(new Superpage(form, start, numPages, layout));
            }

            return superpages;
        }

        public void DrawTo(XGraphics context) {
            foreach (var subpage in subpages) {
                subpage.DrawTo(context);
            }

            DrawBorders(context);
        }

        private void DrawBorders(XGraphics context) {
            var pageWidth = context.PageSize.Width;
            var pageHeight = context.PageSize.Height;
            var borderWidth = pageWidth / layout.Columns;
            var borderHeight = pageHeight / layout.Rows;
            for (uint j = 0; j <= layout.Rows; j++) {
                for (uint i = 0; i <= layout.Columns; i++) {
                    if (j < layout.Rows) {
                        DrawVerticalBorder(context, i, j, borderWidth, borderHeight, layout.IsLeftBorderDotted(i, j));
                    }

                    if (i < layout.Columns) {
                        DrawHorizontalBorder(context, i, j, borderHeight, borderWidth, layout.IsTopBorderDotted(i, j));
                    }
                }
            }
        }

        private static void DrawHorizontalBorder(XGraphics context, uint i, uint j, double borderHeight, double borderWidth, bool dotted) {
            var xpos = i * borderWidth;
            var ypos = j * borderHeight;
            context.DrawLine(MakePen(dotted), xpos, ypos, xpos + borderWidth, ypos);
        }

        private static void DrawVerticalBorder(XGraphics context, uint i, uint j, double borderWidth, double borderHeight, bool dotted) {
            var xpos = i * borderWidth;
            var ypos = j * borderHeight;
            context.DrawLine(MakePen(dotted), xpos, ypos, xpos, ypos + borderHeight);
        }

        private static XPen MakePen(bool dotted) {
            var pen = new XPen(XColors.Black);
            if (dotted) {
                pen.DashStyle = XDashStyle.Dash;
            }

            return pen;
        }
    }
}
