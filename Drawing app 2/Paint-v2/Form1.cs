using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_v2
{
	public partial class Form1 : Form
	{

		Graphics graphics, graphics2;
		Pen pen = new Pen(Color.Black, 3);
		Point px, py;
		bool drawing = false;
		Bitmap bmp;
		Panel panel2 = new Panel();

		public Form1()
		{
			InitializeComponent();
			graphics = panelDraw.CreateGraphics();
			panel2.Width = panelDraw.Width;
			panel2.Height = panelDraw.Height;
			panel2.BackColor = Color.Gainsboro;
			bmp = new Bitmap(panelDraw.Width, panelDraw.Height);
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			graphics2 = Graphics.FromImage(bmp);
			graphics2.Clear(Color.Gainsboro);
			graphics2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			

		}

		private void panelDraw_MouseMove(object sender, MouseEventArgs e)
		{
			if (rBtnPencil.Checked)
			{
				if (drawing == true)
				{
					px = e.Location;
					graphics.DrawLine(pen, px, py);
					graphics2.DrawLine(pen, px, py);
					py = px;
					panelDraw.Cursor = Cursors.Cross;
					panelDraw.BackgroundImage = bmp;
					
				}
			}
		}

		private void panelDraw_MouseUp(object sender, MouseEventArgs e)
		{
			drawing = false;
			panelDraw.Cursor = Cursors.Default;
		}

		private void pBoxDraw_Click(object sender, EventArgs e)
		{
			rBtnPencil.Checked = true;
			pBoxDraw.BackColor = Color.LightGray;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.Filter = "PNG Image|*.png";
			saveFileDialog.Title = "Save an Image File";
			saveFileDialog.DefaultExt = "png";
			saveFileDialog.ShowDialog();

			if (saveFileDialog.FileName != "")
			{
				bmp.Save(saveFileDialog.FileName);
				MessageBox.Show("Image saved!");
				Application.Restart();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			System.Environment.Exit(0);
		}

		private void pBoxClear_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear the canvas?", "Clear Canvas", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				graphics.Clear(Color.Gainsboro);
				graphics2.Clear(Color.Gainsboro);
			}
		}

		private void ColorChange(object sender, EventArgs e)
		{
			Color color = ((PictureBox)sender).BackColor;
			pen.Color = color;
		}

		private void panelDraw_MouseDown(object sender, MouseEventArgs e)
		{
			py = e.Location;

			if (rBtnPencil.Checked)
			{ drawing = true; }

		}

	}
}
