using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using ocenianeForms.diagram;
using ocenianeForms.Properties;
using ocenianeForms.shapes;

namespace ocenianeForms
{
    public partial class Form1 : Form
    {
        private int currentBlock = 0;
        private Diagram diagram;
        private Shape selected = null;
        private Point mousePos = new Point();
        private bool dragging;
        private bool edgeAdding;
        private Point lineStart = new Point();

        public Form1()
        {
            InitializeComponent();
            diagram = new Diagram(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pictureBox1.Image = diagram.GetBitmap();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X - pictureBox1.Padding.Left;
            int y = e.Y - pictureBox1.Padding.Top;
            if (e.Button == MouseButtons.Left)
            {
                Shape shape = null;
                if (currentBlock == 1)
                {
                    shape = new MyRect(x, y);
                }
                else if (currentBlock == 2)
                {
                    shape = new MyRomb(x, y);
                }
                else if (currentBlock == 3)
                {
                    shape = new StartShape(x, y);
                }
                else if (currentBlock == 4)
                {
                    shape = new EndShape(x, y);
                }
                else if (currentBlock == 5 && diagram.selectFullNode(x, y))
                {
                    lineStart.X = x;
                    lineStart.Y = y;
                    mousePos.X = e.X;
                    mousePos.Y = e.Y;
                    edgeAdding = true;
                    return;
                }
                else if (currentBlock == 6)
                {
                    diagram.delete(x, y);
                    pictureBox1.Refresh();
                    return;
                }
                else return;

                try
                {
                    diagram.addShape(shape);
                }
                catch (IOException ex)
                {
                    PromptForm promptForm = new PromptForm(ex.Message);
                    promptForm.ShowDialog();
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                selectElement(x, y);
            }
            else if (e.Button == MouseButtons.Middle && selected != null)
            {
                mousePos.X = e.X;
                mousePos.Y = e.Y;
                pictureBox1.Select();
                dragging = true;
            }

            pictureBox1.Refresh();
        }

        private void newScheme_Click(object sender, EventArgs e)
        {
            NewDiagramForm newDiagramForm = new NewDiagramForm();
            DialogResult dialogresult = newDiagramForm.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                diagram = new Diagram(newDiagramForm.getNewDialogWidth(), newDiagramForm.getNewDialogHeight());
                pictureBox1.Image = diagram.GetBitmap();
                richTextBox1.Enabled = false;
                richTextBox1.Text = "";
            }
        }

        private void saveScheme_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = ".diag | *.diag";
            DialogResult dialogresult = fileDialog.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                using (FileStream fs = System.IO.File.Create(fileDialog.FileName))
                {
                    diagram.Save(fs);
                }
            }
        }

        private void loadSeheme_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ".diag | *.diag";
            DialogResult dialogresult = fileDialog.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                using (FileStream fs = System.IO.File.OpenRead(fileDialog.FileName))
                {
                    try
                    {
                        diagram = Diagram.Read(fs);
                        diagram.refresh();
                        pictureBox1.Image = diagram.GetBitmap();
                        richTextBox1.Enabled = false;
                        richTextBox1.Text = "";
                        selected = diagram.Selected;
                        if (selected != null)
                        {
                            if (selected.isTextEditable())
                            {
                                richTextBox1.Enabled = true;
                            }

                            richTextBox1.Text = diagram.Selected.text;
                        }
                    }
                    catch (Exception)
                    {
                        PromptForm promptForm = new PromptForm(Properties.Strings.can_not_load);
                        promptForm.ShowDialog();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void selectElement(int x, int y)
        {
            selected = diagram.select(x, y);
            if (selected != null)
            {
                richTextBox1.Text = selected.text;
                if (selected.isTextEditable())
                {
                    richTextBox1.Enabled = true;
                }
                else
                {
                    richTextBox1.Enabled = false;
                }
            }
            else
            {
                richTextBox1.Enabled = false;
                richTextBox1.Text = "";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (selected == null) return;
            selected.text = richTextBox1.Text;
            diagram.refresh();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (edgeAdding)
            {
                diagram.refresh();
                diagram.drawLine(lineStart.X, lineStart.Y, e.X - pictureBox1.Padding.Left,
                    e.Y - pictureBox1.Padding.Top);
            }

            if (dragging && selected != null)
            {
                diagram.moveSelected(e.X - mousePos.X, e.Y - mousePos.Y);
                mousePos.X = e.X;
                mousePos.Y = e.Y;
                diagram.refresh();
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && selected != null)
            {
                dragging = false;
            }
            else if (e.Button == MouseButtons.Left && edgeAdding)
            {
                diagram.createNode(lineStart.X, lineStart.Y, e.X - pictureBox1.Padding.Left,
                    e.Y - pictureBox1.Padding.Top);
                edgeAdding = false;
                diagram.refresh();
            }
        }

        private void buttonsColorDefault()
        {
            diamondButton.BackColor = SystemColors.ButtonFace;
            rectangleButton.BackColor = SystemColors.ButtonFace;
            startButton.BackColor = SystemColors.ButtonFace;
            endButton.BackColor = SystemColors.ButtonFace;
            deleteButton.BackColor = SystemColors.ButtonFace;
            conectButton.BackColor = SystemColors.ButtonFace;
        }

        private void rectengleButton_Click(object sender, EventArgs e)
        {
            currentBlock = 1;
            buttonsColorDefault();
            rectangleButton.BackColor = Color.Aqua;
        }

        private void diamondButton_Click(object sender, EventArgs e)
        {
            currentBlock = 2;
            buttonsColorDefault();
            diamondButton.BackColor = Color.Aqua;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            currentBlock = 3;
            buttonsColorDefault();
            startButton.BackColor = Color.Aqua;
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            currentBlock = 4;
            buttonsColorDefault();
            endButton.BackColor = Color.Aqua;
        }

        private void conectButton_Click(object sender, EventArgs e)
        {
            currentBlock = 5;
            buttonsColorDefault();
            conectButton.BackColor = Color.Aqua;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            currentBlock = 6;
            buttonsColorDefault();
            deleteButton.BackColor = Color.Aqua;
        }

        private void refreshForm()
        {
            foreach (Form form in Application.OpenForms)
                form.Invalidate(true);
            var oldDiagram = diagram;
            this.Controls.Clear();
            InitializeComponent();
            this.diagram = oldDiagram;
            pictureBox1.Image = diagram.GetBitmap();
        }

        private void plButton_Click(object sender, EventArgs e)
        {
            ConfigChanger.changeLanguage("pl");
            refreshForm();
        }

        private void engButton_Click(object sender, EventArgs e)
        {
            ConfigChanger.changeLanguage("en-US");
            refreshForm();
        }
    }
}