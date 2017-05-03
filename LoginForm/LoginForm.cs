using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm{

    public partial class LoginForm : Form{

        private bool dragging;// drag boolean 
        private Point offset;// windows location
        private int minutesIdle = 0; // idle time

        private String language = "";// system language
        private String userName = "";
        private String password = "";

        private bool catchTextBoxIsValidUserName = false;
        private bool catchTextBoxIsValidPassword = false;

        private FormValidation fv = new FormValidation();//form validaiton class
        private Database db = new Database();//database class
        private StringOperation so = new StringOperation();// string operation class

        public LoginForm(){
            InitializeComponent();
        }

        public LoginForm(string newUser , String newLanguage):this(){
             userName = newUser;
             language = newLanguage;
        }

        // setting the form componenets as a default
        public void changeFormSettings(){
            if (Properties.Settings.Default.userName != null){
                userText.Text = Properties.Settings.Default.userName;
            }
            if (Properties.Settings.Default.password != null){
                passText.Text = Properties.Settings.Default.password;
            }
            if (Properties.Settings.Default.language != null){
                languageSelectBox.Text = Properties.Settings.Default.language;
            }else {
                languageSelectBox.Text = "Türkçe";
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            passText.PasswordChar = '*';
            this.setLanguage(languageSelectBox);

            titleText.Font = new Font(titleText.Font , FontStyle.Bold);
            usernameText.Font = new Font(usernameText.Font, FontStyle.Bold);
            passwordText.Font = new Font(passwordText.Font, FontStyle.Bold);
            languageText.Font = new Font(languageText.Font, FontStyle.Bold);
            savePasswordCheck.Font = new Font(savePasswordCheck.Font, FontStyle.Bold);
            loginBeforeData.Font = new Font(loginBeforeData.Font, FontStyle.Bold);
            loginButton.Font = new Font(loginButton.Font, FontStyle.Bold);
            changePaswordButton.Font = new Font(changePaswordButton.Font, FontStyle.Bold);
            resultText.Font = new Font(resultText.Font, FontStyle.Bold);
            resultText.ForeColor = Color.Red;
            resultText2.Font = new Font(resultText2.Font, FontStyle.Bold);
            resultText2.ForeColor = Color.Red;

            loginButton.BackColor = Color.DarkTurquoise;
            changePaswordButton.BackColor = Color.DarkTurquoise;
        }

        //setting system language
        public void setLanguage(ComboBox select){
            using (System.IO.StreamReader r = new System.IO.StreamReader("json_data/language.json", Encoding.GetEncoding("iso-8859-9"), false)){
                string json = r.ReadToEnd();
                var jsonResponse = JObject.Parse(json);
                var turkishReponse = jsonResponse["tr"] as JObject;
                var englishResponse = jsonResponse["en"] as JObject;
                String langVal = languageSelectBox.SelectedItem.ToString();
                switch (langVal){
                    case "Türkçe":
                        this.Text = turkishReponse["title"].ToString();
                        titleText.Text = turkishReponse["titletext"].ToString();
                        usernameText.Text = turkishReponse["usernametext"].ToString();
                        passwordText.Text = turkishReponse["passwordtext"].ToString();
                        languageText.Text = turkishReponse["languagetext"].ToString();
                        savePasswordCheck.Text = turkishReponse["savepassword"].ToString();
                        loginBeforeData.Text = turkishReponse["loginbeforedata"].ToString();
                        loginButton.Text = turkishReponse["loginbutton"].ToString();
                        changePaswordButton.Text = turkishReponse["changepassword"].ToString();
                        break;

                    case "English":
                        this.Text = englishResponse["title"].ToString();
                        titleText.Text = englishResponse["titletext"].ToString();
                        usernameText.Text = englishResponse["usernametext"].ToString();
                        passwordText.Text = englishResponse["passwordtext"].ToString();
                        languageText.Text = englishResponse["languagetext"].ToString();
                        savePasswordCheck.Text = englishResponse["savepassword"].ToString();
                        loginBeforeData.Text = englishResponse["loginbeforedata"].ToString();
                        loginButton.Text = englishResponse["loginbutton"].ToString();
                        changePaswordButton.Text = englishResponse["changepassword"].ToString();
                        break;

                    default:
                        Console.WriteLine("Hatalı Seçim !");
                        break;
                }
                resultText.Text = "";
                resultText2.Text = "";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e){
            userText.Text = userName;
            languageSelectBox.Text = language;
            this.changeFormSettings();
        }

        private void languageSelectBox_SelectedIndexChanged(object sender, EventArgs e){
            this.setLanguage(languageSelectBox);
        }

        private void loginButton_Click(object sender, EventArgs e){
            resultText.Text = "";
            resultText2.Text = "";
            //if (this.isIdle(10)){ // control the system is active or inactive for about 10 minutes
                language = languageSelectBox.SelectedItem.ToString();
                userName = userText.Text;
                password = passText.Text;
                Boolean goon = true;
                if (fv.validIsExist(userName)){// control username and password is null or not
                    catchTextBoxIsValidUserName = true;
                    if (language == "Türkçe"){
                        resultText.Text += "\nLütfen kullanıcı adınızı boş bırakmayın !\n";
                    }else{
                        resultText.Text += "\nPlease don't leave blank your username !\n";
                    }
                    goon = false;
                }

                if (fv.validIsExist(password)){
                    catchTextBoxIsValidPassword = true;
                    if (language == "Türkçe"){
                        resultText2.Text = "\nLütfen şifrenizi boş bırakmayın !\n";
                    }else{ 
                        resultText2.Text = "\nPlease don't leave blank your password !\n";
                    }   
                    goon = false;
                }

                if (goon){
                    // save the password if is the checked
                    if (savePasswordCheck.Checked){
                        Properties.Settings.Default.password = password;
                        Properties.Settings.Default.Save();
                    }
                    //save the previous information if is checked
                    if (loginBeforeData.Checked){
                        Properties.Settings.Default.userName = userName;
                        Properties.Settings.Default.password = password;
                        Properties.Settings.Default.language = language;
                        Properties.Settings.Default.Save();
                    }
                    password = so.textToMD5(password);// encrypt your password for private security
                    String result = db.loginOperation(userName, password, language,this);// login control
                    if (result.Length > 0){// if there is a message  , press the message to screen
                        resultText.Text = result;
                    }else{
                        resultText.Text = "";
                        resultText2.Text = "";
                    }
                }
                Global.systemLang = languageSelectBox.SelectedItem.ToString();
                Global.systemUserName = userName;
            //}else {
                //this.Close(); // if idle time is bigger than 10 minutes close the programme
            //}
        }

        //control the system with idle time
        private bool isIdle(int minutes){
            return minutesIdle >= minutes;
        }

        // calculate the idle time
        private void idleTimer_Tick(object sender, EventArgs e){
            if (Cursor.Position != offset){
                // The mouse moved since last check
                minutesIdle = 0;
            }else{
                // Mouse still stoped
                minutesIdle++;
            }
            // Save current position
            offset = Cursor.Position;
        }

        //moveable frame operations start
        private void LoginForm_MouseDown(object sender, MouseEventArgs e){
            dragging = true;
            offset = e.Location; 
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e){
            dragging = false;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e){
            if (dragging){
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            } 
        }
        //moveable frame operations finish

        //getter Methods for username , password and system language
        public TextBox getUserName(){
            return userText;
        }

        public String getPassword(){
            return passText.Text;
        }

        public ComboBox getLanguage(){
            return languageSelectBox;
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e){
            if (catchTextBoxIsValidUserName){
                userText.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(userText.Location.X - variance, userText.Location.Y - variance, userText.Width + variance, userText.Height + variance));
            } else{
                userText.BorderStyle = BorderStyle.FixedSingle;
            }
            if (catchTextBoxIsValidPassword){
                passText.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(passText.Location.X - variance, passText.Location.Y - variance, passText.Width + variance, passText.Height + variance));
            }else{
                passText.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void userText_Enter(object sender, EventArgs e){
            if (fv.validIsExist(userText.Text)){
                catchTextBoxIsValidUserName = true;
            }else {
                catchTextBoxIsValidUserName = false;
            }
            this.Refresh();
        }

        private void passText_Enter(object sender, EventArgs e){
            if (fv.validIsExist(passText.Text)){
                catchTextBoxIsValidPassword = true;
            }else {
                catchTextBoxIsValidPassword = false;
            }
            this.Refresh();
        }

        public class Language{
            public String tr;
            public String en;
            public String title;
            public String titletext;
            public String usernametext;
            public String passwordtext;
            public String languagetext;
            public String savepassword;
            public String loginbeforedata;
            public String loginbutton;
            public String changepassword;
        }
    }
}
