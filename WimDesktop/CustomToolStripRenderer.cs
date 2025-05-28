using System.Drawing;
using System.Windows.Forms;

namespace WimDesktop
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton button = e.Item as ToolStripButton;

            if (button != null && button.Checked)
            {
                Rectangle bounds = new Rectangle(Point.Empty, button.Size);
                using (Brush b = new SolidBrush(Color.LightGray))
                {
                    e.Graphics.FillRectangle(b, bounds);
                }
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }
    }

}
