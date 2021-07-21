namespace FileMonitorHook
{
    partial class MacroRecorderDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.macrosHint = new System.Windows.Forms.Label();
            this.macrosList = new System.Windows.Forms.ListBox();
            this.macrosRecord = new System.Windows.Forms.Button();
            this.macrosTrim = new System.Windows.Forms.Button();
            this.macrosSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.macrosName = new System.Windows.Forms.TextBox();
            this.macrosNameLabel = new System.Windows.Forms.Label();
            this.setMode = new System.Windows.Forms.Button();
            this.mode = new System.Windows.Forms.Label();
            this.setActivators = new System.Windows.Forms.Button();
            this.keysLabel = new System.Windows.Forms.Label();
            this.activatorKeys = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(24, 18);
            label1.MaximumSize = new System.Drawing.Size(250, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(236, 48);
            label1.TabIndex = 1;
            label1.Text = "Inputs will be recorded after you press a key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("OCR B MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.DarkCyan;
            label2.Location = new System.Drawing.Point(317, 18);
            label2.MaximumSize = new System.Drawing.Size(300, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(177, 16);
            label2.TabIndex = 2;
            label2.Text = "Macro Utility";
            // 
            // macrosHint
            // 
            this.macrosHint.AutoSize = true;
            this.macrosHint.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosHint.ForeColor = System.Drawing.Color.LightSlateGray;
            this.macrosHint.Location = new System.Drawing.Point(80, 288);
            this.macrosHint.MaximumSize = new System.Drawing.Size(350, 0);
            this.macrosHint.Name = "macrosHint";
            this.macrosHint.Size = new System.Drawing.Size(332, 16);
            this.macrosHint.TabIndex = 9;
            this.macrosHint.Text = "Begin Remote Play or PS Now";
            // 
            // macrosList
            // 
            this.macrosList.Font = new System.Drawing.Font("OCR-A II", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosList.FormattingEnabled = true;
            this.macrosList.ItemHeight = 15;
            this.macrosList.Location = new System.Drawing.Point(12, 185);
            this.macrosList.Name = "macrosList";
            this.macrosList.Size = new System.Drawing.Size(482, 334);
            this.macrosList.TabIndex = 0;
            this.macrosList.Visible = false;
            // 
            // macrosRecord
            // 
            this.macrosRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.macrosRecord.FlatAppearance.BorderSize = 0;
            this.macrosRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.macrosRecord.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosRecord.ForeColor = System.Drawing.Color.White;
            this.macrosRecord.Location = new System.Drawing.Point(12, 542);
            this.macrosRecord.Name = "macrosRecord";
            this.macrosRecord.Size = new System.Drawing.Size(127, 39);
            this.macrosRecord.TabIndex = 5;
            this.macrosRecord.Text = "Record";
            this.macrosRecord.UseVisualStyleBackColor = false;
            this.macrosRecord.Click += new System.EventHandler(this.macrosRecord_Click);
            // 
            // macrosTrim
            // 
            this.macrosTrim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.macrosTrim.FlatAppearance.BorderSize = 0;
            this.macrosTrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.macrosTrim.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosTrim.ForeColor = System.Drawing.Color.White;
            this.macrosTrim.Location = new System.Drawing.Point(145, 542);
            this.macrosTrim.Name = "macrosTrim";
            this.macrosTrim.Size = new System.Drawing.Size(127, 39);
            this.macrosTrim.TabIndex = 6;
            this.macrosTrim.Text = "Trim";
            this.macrosTrim.UseVisualStyleBackColor = false;
            this.macrosTrim.Visible = false;
            this.macrosTrim.Click += new System.EventHandler(this.macrosTrim_Click);
            // 
            // macrosSave
            // 
            this.macrosSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.macrosSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.macrosSave.FlatAppearance.BorderSize = 0;
            this.macrosSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.macrosSave.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosSave.ForeColor = System.Drawing.Color.White;
            this.macrosSave.Location = new System.Drawing.Point(367, 589);
            this.macrosSave.Name = "macrosSave";
            this.macrosSave.Size = new System.Drawing.Size(127, 39);
            this.macrosSave.TabIndex = 7;
            this.macrosSave.Text = "Save";
            this.macrosSave.UseVisualStyleBackColor = false;
            this.macrosSave.Visible = false;
            this.macrosSave.Click += new System.EventHandler(this.macrosSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(100)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(367, 542);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.macrosCancel_Click);
            // 
            // macrosName
            // 
            this.macrosName.Location = new System.Drawing.Point(83, 597);
            this.macrosName.Name = "macrosName";
            this.macrosName.Size = new System.Drawing.Size(273, 22);
            this.macrosName.TabIndex = 10;
            this.macrosName.Visible = false;
            // 
            // macrosNameLabel
            // 
            this.macrosNameLabel.AutoSize = true;
            this.macrosNameLabel.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macrosNameLabel.ForeColor = System.Drawing.Color.LightSlateGray;
            this.macrosNameLabel.Location = new System.Drawing.Point(12, 600);
            this.macrosNameLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.macrosNameLabel.Name = "macrosNameLabel";
            this.macrosNameLabel.Size = new System.Drawing.Size(68, 16);
            this.macrosNameLabel.TabIndex = 11;
            this.macrosNameLabel.Text = "Name:";
            this.macrosNameLabel.Visible = false;
            // 
            // setMode
            // 
            this.setMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setMode.FlatAppearance.BorderSize = 0;
            this.setMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMode.Font = new System.Drawing.Font("OCR B MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setMode.ForeColor = System.Drawing.Color.White;
            this.setMode.Location = new System.Drawing.Point(27, 140);
            this.setMode.Name = "setMode";
            this.setMode.Size = new System.Drawing.Size(127, 39);
            this.setMode.TabIndex = 13;
            this.setMode.Text = "Mode";
            this.setMode.UseVisualStyleBackColor = false;
            this.setMode.Visible = false;
            this.setMode.Click += new System.EventHandler(this.setMode_Click);
            // 
            // mode
            // 
            this.mode.AutoSize = true;
            this.mode.Font = new System.Drawing.Font("OCR-A II", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mode.ForeColor = System.Drawing.Color.SlateGray;
            this.mode.Location = new System.Drawing.Point(160, 149);
            this.mode.MaximumSize = new System.Drawing.Size(350, 0);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(75, 19);
            this.mode.TabIndex = 14;
            this.mode.Text = "Toggle";
            this.mode.Visible = false;
            // 
            // setActivators
            // 
            this.setActivators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setActivators.FlatAppearance.BorderSize = 0;
            this.setActivators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setActivators.Font = new System.Drawing.Font("OCR B MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setActivators.ForeColor = System.Drawing.Color.White;
            this.setActivators.Location = new System.Drawing.Point(27, 95);
            this.setActivators.Name = "setActivators";
            this.setActivators.Size = new System.Drawing.Size(127, 39);
            this.setActivators.TabIndex = 15;
            this.setActivators.Text = "Set Activators";
            this.setActivators.UseVisualStyleBackColor = false;
            this.setActivators.Visible = false;
            this.setActivators.Click += new System.EventHandler(this.setActivators_Click);
            // 
            // keysLabel
            // 
            this.keysLabel.AutoSize = true;
            this.keysLabel.Font = new System.Drawing.Font("OCR-A II", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keysLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.keysLabel.Location = new System.Drawing.Point(160, 103);
            this.keysLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.keysLabel.Name = "keysLabel";
            this.keysLabel.Size = new System.Drawing.Size(64, 19);
            this.keysLabel.TabIndex = 16;
            this.keysLabel.Text = "Keys:";
            this.keysLabel.Visible = false;
            // 
            // activatorKeys
            // 
            this.activatorKeys.AutoSize = true;
            this.activatorKeys.Font = new System.Drawing.Font("OCR-A II", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activatorKeys.ForeColor = System.Drawing.Color.SlateGray;
            this.activatorKeys.Location = new System.Drawing.Point(248, 103);
            this.activatorKeys.MaximumSize = new System.Drawing.Size(350, 0);
            this.activatorKeys.Name = "activatorKeys";
            this.activatorKeys.Size = new System.Drawing.Size(0, 19);
            this.activatorKeys.TabIndex = 17;
            // 
            // MacroRecorderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(506, 640);
            this.Controls.Add(this.activatorKeys);
            this.Controls.Add(this.keysLabel);
            this.Controls.Add(this.setActivators);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.setMode);
            this.Controls.Add(this.macrosNameLabel);
            this.Controls.Add(this.macrosName);
            this.Controls.Add(this.macrosHint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.macrosSave);
            this.Controls.Add(this.macrosTrim);
            this.Controls.Add(this.macrosRecord);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.macrosList);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MacroRecorderDialog";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox macrosList;
        private System.Windows.Forms.Button macrosRecord;
        private System.Windows.Forms.Button macrosTrim;
        private System.Windows.Forms.Button macrosSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label macrosHint;
        private System.Windows.Forms.TextBox macrosName;
        private System.Windows.Forms.Label macrosNameLabel;
        private System.Windows.Forms.Button setMode;
        private System.Windows.Forms.Label mode;
        private System.Windows.Forms.Button setActivators;
        private System.Windows.Forms.Label keysLabel;
        private System.Windows.Forms.Label activatorKeys;
    }
}