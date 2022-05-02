
namespace ocenianeForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.File = new System.Windows.Forms.GroupBox();
            this.loadSeheme = new System.Windows.Forms.Button();
            this.saveScheme = new System.Windows.Forms.Button();
            this.newScheme = new System.Windows.Forms.Button();
            this.Edycja = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.conectButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.diamondButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.Jezyk = new System.Windows.Forms.GroupBox();
            this.engButton = new System.Windows.Forms.Button();
            this.plButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.File.SuspendLayout();
            this.Edycja.SuspendLayout();
            this.Jezyk.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.File, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Edycja, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Jezyk, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // File
            // 
            resources.ApplyResources(this.File, "File");
            this.File.Controls.Add(this.loadSeheme);
            this.File.Controls.Add(this.saveScheme);
            this.File.Controls.Add(this.newScheme);
            this.File.Name = "File";
            this.File.TabStop = false;
            this.File.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // loadSeheme
            // 
            resources.ApplyResources(this.loadSeheme, "loadSeheme");
            this.loadSeheme.Name = "loadSeheme";
            this.loadSeheme.UseVisualStyleBackColor = true;
            this.loadSeheme.Click += new System.EventHandler(this.loadSeheme_Click);
            // 
            // saveScheme
            // 
            resources.ApplyResources(this.saveScheme, "saveScheme");
            this.saveScheme.Name = "saveScheme";
            this.saveScheme.UseVisualStyleBackColor = true;
            this.saveScheme.Click += new System.EventHandler(this.saveScheme_Click);
            // 
            // newScheme
            // 
            resources.ApplyResources(this.newScheme, "newScheme");
            this.newScheme.Name = "newScheme";
            this.newScheme.UseVisualStyleBackColor = true;
            this.newScheme.Click += new System.EventHandler(this.newScheme_Click);
            // 
            // Edycja
            // 
            resources.ApplyResources(this.Edycja, "Edycja");
            this.Edycja.Controls.Add(this.deleteButton);
            this.Edycja.Controls.Add(this.conectButton);
            this.Edycja.Controls.Add(this.endButton);
            this.Edycja.Controls.Add(this.startButton);
            this.Edycja.Controls.Add(this.diamondButton);
            this.Edycja.Controls.Add(this.rectangleButton);
            this.Edycja.Name = "Edycja";
            this.Edycja.TabStop = false;
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // conectButton
            // 
            resources.ApplyResources(this.conectButton, "conectButton");
            this.conectButton.Name = "conectButton";
            this.conectButton.UseVisualStyleBackColor = true;
            this.conectButton.Click += new System.EventHandler(this.conectButton_Click);
            // 
            // endButton
            // 
            resources.ApplyResources(this.endButton, "endButton");
            this.endButton.Name = "endButton";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // diamondButton
            // 
            resources.ApplyResources(this.diamondButton, "diamondButton");
            this.diamondButton.Name = "diamondButton";
            this.diamondButton.UseVisualStyleBackColor = true;
            this.diamondButton.Click += new System.EventHandler(this.diamondButton_Click);
            // 
            // rectangleButton
            // 
            resources.ApplyResources(this.rectangleButton, "rectangleButton");
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectengleButton_Click);
            // 
            // Jezyk
            // 
            resources.ApplyResources(this.Jezyk, "Jezyk");
            this.Jezyk.Controls.Add(this.engButton);
            this.Jezyk.Controls.Add(this.plButton);
            this.Jezyk.Name = "Jezyk";
            this.Jezyk.TabStop = false;
            // 
            // engButton
            // 
            resources.ApplyResources(this.engButton, "engButton");
            this.engButton.Name = "engButton";
            this.engButton.UseVisualStyleBackColor = true;
            this.engButton.Click += new System.EventHandler(this.engButton_Click);
            // 
            // plButton
            // 
            resources.ApplyResources(this.plButton, "plButton");
            this.plButton.Name = "plButton";
            this.plButton.UseVisualStyleBackColor = true;
            this.plButton.Click += new System.EventHandler(this.plButton_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.File.ResumeLayout(false);
            this.Edycja.ResumeLayout(false);
            this.Jezyk.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox File;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Edycja;
        private System.Windows.Forms.GroupBox Jezyk;
        private System.Windows.Forms.Button loadSeheme;
        private System.Windows.Forms.Button saveScheme;
        private System.Windows.Forms.Button newScheme;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button diamondButton;
        private System.Windows.Forms.Button plButton;
        private System.Windows.Forms.Button engButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button conectButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button startButton;
    }
}

