
namespace stomatoloska_ordinacija.Administracija
{
    partial class ManageZahvata
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
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputTrajanje = new System.Windows.Forms.ComboBox();
            this.Odustani = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.inputCijena = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.inputSifra = new System.Windows.Forms.TextBox();
            this.inputNaziv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputCijena)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(12, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(117, 24);
            this.title.TabIndex = 0;
            this.title.Text = "Novi zahvat";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputTrajanje);
            this.panel1.Controls.Add(this.Odustani);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.inputCijena);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.inputSifra);
            this.panel1.Controls.Add(this.inputNaziv);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 385);
            this.panel1.TabIndex = 1;
            // 
            // inputTrajanje
            // 
            this.inputTrajanje.AllowDrop = true;
            this.inputTrajanje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputTrajanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputTrajanje.FormattingEnabled = true;
            this.inputTrajanje.Location = new System.Drawing.Point(12, 231);
            this.inputTrajanje.Name = "inputTrajanje";
            this.inputTrajanje.Size = new System.Drawing.Size(137, 28);
            this.inputTrajanje.TabIndex = 4;
            // 
            // Odustani
            // 
            this.Odustani.BackColor = System.Drawing.Color.Red;
            this.Odustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Odustani.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Odustani.Location = new System.Drawing.Point(119, 329);
            this.Odustani.Name = "Odustani";
            this.Odustani.Size = new System.Drawing.Size(104, 34);
            this.Odustani.TabIndex = 6;
            this.Odustani.Text = "Odustani";
            this.Odustani.UseVisualStyleBackColor = false;
            this.Odustani.Click += new System.EventHandler(this.Odustani_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(229, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Spremi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trajanje";
            // 
            // inputCijena
            // 
            this.inputCijena.DecimalPlaces = 2;
            this.inputCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputCijena.Location = new System.Drawing.Point(12, 167);
            this.inputCijena.Name = "inputCijena";
            this.inputCijena.Size = new System.Drawing.Size(137, 26);
            this.inputCijena.TabIndex = 3;
            this.inputCijena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputCijena.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cijena";
            // 
            // inputSifra
            // 
            this.inputSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputSifra.Location = new System.Drawing.Point(12, 39);
            this.inputSifra.Name = "inputSifra";
            this.inputSifra.Size = new System.Drawing.Size(326, 26);
            this.inputSifra.TabIndex = 1;
            // 
            // inputNaziv
            // 
            this.inputNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputNaziv.Location = new System.Drawing.Point(12, 103);
            this.inputNaziv.Name = "inputNaziv";
            this.inputNaziv.Size = new System.Drawing.Size(326, 26);
            this.inputNaziv.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Šifra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // ManageZahvata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.Name = "ManageZahvata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novi zahvat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputCijena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputCijena;
        private System.Windows.Forms.ComboBox inputTrajanje;
        private System.Windows.Forms.Button Odustani;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputSifra;
        private System.Windows.Forms.Label label4;
    }
}