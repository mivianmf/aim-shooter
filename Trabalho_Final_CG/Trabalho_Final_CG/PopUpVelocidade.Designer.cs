namespace Trabalho_Final_CG
{
    partial class PopUpVelocidade
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
            this.comboVelocidade = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelEscolha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboVelocidade
            // 
            this.comboVelocidade.FormattingEnabled = true;
            this.comboVelocidade.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboVelocidade.Location = new System.Drawing.Point(241, 38);
            this.comboVelocidade.Name = "comboVelocidade";
            this.comboVelocidade.Size = new System.Drawing.Size(160, 21);
            this.comboVelocidade.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(409, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelEscolha
            // 
            this.labelEscolha.AutoSize = true;
            this.labelEscolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscolha.Location = new System.Drawing.Point(13, 38);
            this.labelEscolha.Name = "labelEscolha";
            this.labelEscolha.Size = new System.Drawing.Size(222, 20);
            this.labelEscolha.TabIndex = 2;
            this.labelEscolha.Text = "Escolha a veolcidade de jogo: ";
            // 
            // PopUpVelocidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 90);
            this.Controls.Add(this.labelEscolha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboVelocidade);
            this.Name = "PopUpVelocidade";
            this.Text = "PopUpVelocidade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboVelocidade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelEscolha;
    }
}