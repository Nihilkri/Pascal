using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pascal {
	public partial class Form1 : Form {
		#region Variables
		#region Graphics
		Graphics gf, gb; Bitmap gi;
		int fx, fy, fx2, fy2;

		#endregion Graphics

		#endregion Variables

		#region Events
		public Form1() {InitializeComponent();}

		private void Form1_Load(object sender, EventArgs e) {
			fx = Width = Screen.PrimaryScreen.WorkingArea.Width; fx2 = fx / 2; Left = 0;
			fy = Height = Screen.PrimaryScreen.WorkingArea.Height; fy2 = fy / 2; Top = 0;
			gf = CreateGraphics(); gi = new Bitmap(fx, fy); gb = Graphics.FromImage(gi);

		}
		private void Form1_Paint(object sender, PaintEventArgs e) {
			gf.DrawImage(gi, 0, 0);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); break;
				case Keys.Space: Calc(); break;
				default: break;
			}
		}
		#endregion Events

		private void Calc() {
			gb.Clear(Color.Black); int q = 0, p = 0, ym = fy;
			int[] i = new int[(ym + ym) / 2 * ym]; i[0] = 1;
			for(int y = 1; y < ym; y++) {
				p = q; q += y;
				for(int x = 0; x <= y; x++) {
					i[q+x] = ((x==0)?0:i[p+x-1]) + ((x==y)?0:i[p+x]);
					if(i[q + x] % 2 == 1) gi.SetPixel(x, y, Color.White);
					//gb.DrawString(i[q+x].ToString(), Font, Brushes.White, x*40, y*20);

				}
			}
			//gb.DrawString(String.Format("{0}, {1}", fx, fy), Font, Brushes.White, 0, 0);

			Invalidate();

		}
	}

}
