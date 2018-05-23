namespace WindowsFormsApplication1 { 
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label_description_of_bingo = new System.Windows.Forms.Label();
            this.button_go = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_your_name = new System.Windows.Forms.Label();
            this.textBox_enter_name = new System.Windows.Forms.TextBox();
            this.textBox_number_called = new System.Windows.Forms.TextBox();
            this.button_dont_have = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_description_of_bingo
            // 
            this.label_description_of_bingo.AutoEllipsis = true;
            this.label_description_of_bingo.AutoSize = true;
            this.label_description_of_bingo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_description_of_bingo.Location = new System.Drawing.Point(12, 9);
            this.label_description_of_bingo.Name = "label_description_of_bingo";
            this.label_description_of_bingo.Size = new System.Drawing.Size(488, 50);
            this.label_description_of_bingo.TabIndex = 0;
            this.label_description_of_bingo.Text = "This is a bingo game. Enter your name and press \r\n\"go\" to start or exit with \"exi" +
    "t\"";
            this.label_description_of_bingo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_go
            // 
            this.button_go.BackColor = System.Drawing.Color.Green;
            this.button_go.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_go.Location = new System.Drawing.Point(19, 108);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(122, 48);
            this.button_go.TabIndex = 1;
            this.button_go.Text = "Go!";
            this.button_go.UseVisualStyleBackColor = false;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Maroon;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Location = new System.Drawing.Point(188, 108);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(122, 48);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "Exit.";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // label_your_name
            // 
            this.label_your_name.AutoEllipsis = true;
            this.label_your_name.AutoSize = true;
            this.label_your_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_your_name.Location = new System.Drawing.Point(21, 65);
            this.label_your_name.Name = "label_your_name";
            this.label_your_name.Size = new System.Drawing.Size(123, 25);
            this.label_your_name.TabIndex = 4;
            this.label_your_name.Text = "Your name:";
            this.label_your_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_enter_name
            // 
            this.textBox_enter_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_enter_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_enter_name.Location = new System.Drawing.Point(170, 62);
            this.textBox_enter_name.Name = "textBox_enter_name";
            this.textBox_enter_name.Size = new System.Drawing.Size(149, 31);
            this.textBox_enter_name.TabIndex = 5;
            // 
            // textBox_number_called
            // 
            this.textBox_number_called.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_number_called.Enabled = false;
            this.textBox_number_called.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_number_called.Location = new System.Drawing.Point(374, 112);
            this.textBox_number_called.Name = "textBox_number_called";
            this.textBox_number_called.ReadOnly = true;
            this.textBox_number_called.Size = new System.Drawing.Size(126, 44);
            this.textBox_number_called.TabIndex = 6;
            this.textBox_number_called.Visible = false;
            // 
            // button_dont_have
            // 
            this.button_dont_have.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_dont_have.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dont_have.Location = new System.Drawing.Point(377, 58);
            this.button_dont_have.Name = "button_dont_have";
            this.button_dont_have.Size = new System.Drawing.Size(122, 48);
            this.button_dont_have.TabIndex = 7;
            this.button_dont_have.Text = "Don\'t have";
            this.button_dont_have.UseVisualStyleBackColor = false;
            this.button_dont_have.Visible = false;
            this.button_dont_have.Click += new System.EventHandler(this.button_dont_have_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 703);
            this.Controls.Add(this.button_dont_have);
            this.Controls.Add(this.textBox_number_called);
            this.Controls.Add(this.textBox_enter_name);
            this.Controls.Add(this.label_your_name);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.label_description_of_bingo);
            this.Name = "UserInterface";
            this.Text = "And bingo was his name-o";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_description_of_bingo;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_your_name;
        private System.Windows.Forms.TextBox textBox_enter_name;
        private System.Windows.Forms.TextBox textBox_number_called;
        private System.Windows.Forms.Button button_dont_have;
    }
}

