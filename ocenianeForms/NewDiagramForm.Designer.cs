
using System;

namespace ocenianeForms
{
    partial class NewDiagramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        public int getNewDialogWidth()
        {
            return Decimal.ToInt32(widthField.Value);
        }

        public int getNewDialogHeight()
        {
            return Decimal.ToInt32(heightField.Value);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDiagramForm));
            this.widthField = new System.Windows.Forms.NumericUpDown();
            this.heightField = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightField)).BeginInit();
            this.SuspendLayout();
            // 
            // widthField
            // 
            resources.ApplyResources(this.widthField, "widthField");
            this.widthField.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthField.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.widthField.Name = "widthField";
            this.widthField.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // heightField
            // 
            resources.ApplyResources(this.heightField, "heightField");
            this.heightField.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightField.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.heightField.Name = "heightField";
            this.heightField.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NewDiagramForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightField);
            this.Controls.Add(this.widthField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewDiagramForm";
            ((System.ComponentModel.ISupportInitialize)(this.widthField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown widthField;
        private System.Windows.Forms.NumericUpDown heightField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}