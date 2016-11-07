using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTramYTe.Classes
{
    public class MoveFrame
    {
        Control control;
        public MoveFrame(Control control)
        {
            this.control=control;

            control.MouseMove+=new MouseEventHandler(mouseMove);
            control.MouseDown+=new MouseEventHandler(mouseDown);
            control.MouseUp+=new MouseEventHandler(mouseUp);
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = control.PointToScreen(e.Location);
                control.Parent.Location=new Point(p.X-this._start_point.X, p.Y-this._start_point.Y);
            }
        }
        private void mouseDown(object sender, MouseEventArgs e)
        {
            _dragging=true;  // _dragging is your variable flag
            _start_point=new Point(e.X, e.Y);
        }
        private void mouseUp(object sender, MouseEventArgs e)
        {
            _dragging=false;
        }
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
    }//end class
}
