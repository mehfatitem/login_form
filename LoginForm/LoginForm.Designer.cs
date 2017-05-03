namespace LoginForm
{
    partial class LoginForm
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
            this.usernameText = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.Label();
            this.languageText = new System.Windows.Forms.Label();
            this.userText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.languageSelectBox = new System.Windows.Forms.ComboBox();
            this.savePasswordCheck = new System.Windows.Forms.CheckBox();
            this.loginBeforeData = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.changePaswordButton = new System.Windows.Forms.Button();
            this.resultText = new System.Windows.Forms.Label();
            this.resultText2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Location = new System.Drawing.Point(48, 65);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(35, 13);
            this.usernameText.TabIndex = 0;
            this.usernameText.Text = "label1";
            // 
            // passwordText
            // 
            this.passwordText.AutoSize = true;
            this.passwordText.Location = new System.Drawing.Point(48, 118);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(35, 13);
            this.passwordText.TabIndex = 1;
            this.passwordText.Text = "label1";
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Location = new System.Drawing.Point(148, 40);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(35, 13);
            this.titleText.TabIndex = 2;
            this.titleText.Text = "label1";
            // 
            // languageText
            // 
            this.languageText.AutoSize = true;
            this.languageText.Location = new System.Drawing.Point(48, 178);
            this.languageText.Name = "languageText";
            this.languageText.Size = new System.Drawing.Size(35, 13);
            this.languageText.TabIndex = 3;
            this.languageText.Text = "label1";
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(133, 62);
            this.userText.Multiline = true;
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(203, 26);
            this.userText.TabIndex = 4;
            this.userText.Enter += new System.EventHandler(this.userText_Enter);
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(133, 115);
            this.passText.Multiline = true;
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(203, 28);
            this.passText.TabIndex = 5;
            this.passText.Enter += new System.EventHandler(this.passText_Enter);
            // 
            // languageSelectBox
            // 
            this.languageSelectBox.FormattingEnabled = true;
            this.languageSelectBox.Items.AddRange(new object[] {
            "Türkçe",
            "English"});
            this.languageSelectBox.Location = new System.Drawing.Point(133, 170);
            this.languageSelectBox.Name = "languageSelectBox";
            this.languageSelectBox.Size = new System.Drawing.Size(203, 21);
            this.languageSelectBox.TabIndex = 6;
            this.languageSelectBox.SelectedIndexChanged += new System.EventHandler(this.languageSelectBox_SelectedIndexChanged);
            // 
            // savePasswordCheck
            // 
            this.savePasswordCheck.AutoSize = true;
            this.savePasswordCheck.Location = new System.Drawing.Point(133, 216);
            this.savePasswordCheck.Name = "savePasswordCheck";
            this.savePasswordCheck.Size = new System.Drawing.Size(80, 17);
            this.savePasswordCheck.TabIndex = 7;
            this.savePasswordCheck.Text = "checkBox1";
            this.savePasswordCheck.UseVisualStyleBackColor = true;
            // 
            // loginBeforeData
            // 
            this.loginBeforeData.AutoSize = true;
            this.loginBeforeData.Location = new System.Drawing.Point(133, 240);
            this.loginBeforeData.Name = "loginBeforeData";
            this.loginBeforeData.Size = new System.Drawing.Size(80, 17);
            this.loginBeforeData.TabIndex = 8;
            this.loginBeforeData.Text = "checkBox2";
            this.loginBeforeData.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(51, 276);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(162, 37);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "button1";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // changePaswordButton
            // 
            this.changePaswordButton.Location = new System.Drawing.Point(219, 276);
            this.changePaswordButton.Name = "changePaswordButton";
            this.changePaswordButton.Size = new System.Drawing.Size(117, 37);
            this.changePaswordButton.TabIndex = 10;
            this.changePaswordButton.Text = "button2";
            this.changePaswordButton.UseVisualStyleBackColor = true;
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Location = new System.Drawing.Point(83, 333);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(0, 13);
            this.resultText.TabIndex = 11;
            // 
            // resultText2
            // 
            this.resultText2.AutoSize = true;
            this.resultText2.Location = new System.Drawing.Point(83, 362);
            this.resultText2.Name = "resultText2";
            this.resultText2.Size = new System.Drawing.Size(0, 13);
            this.resultText2.TabIndex = 12;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 409);
            this.Controls.Add(this.resultText2);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.changePaswordButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginBeforeData);
            this.Controls.Add(this.savePasswordCheck);
            this.Controls.Add(this.languageSelectBox);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.languageText);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.Label passwordText;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label languageText;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.ComboBox languageSelectBox;
        private System.Windows.Forms.CheckBox savePasswordCheck;
        private System.Windows.Forms.CheckBox loginBeforeData;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button changePaswordButton;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.Label resultText2;
    }
}

