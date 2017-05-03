using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm{

    public partial class AdminPanel : Form{
        private Database db = new Database();
        private LoginForm lf = new LoginForm();
        public AdminPanel(){
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e){
            ComboBox language = lf.getLanguage();
            TextBox userName = lf.getUserName();
            String txtLanguage = language.Text;
            String txtUserName = userName.Text;
            String contact = db.getContact(txtUserName);// get logged in user contact
            if (txtLanguage == "Türkçe")
            {
                welcomeText.Text = "Admin Paneline Hoş geldiniz" + contact + "...";
            }else{
                welcomeText.Text = "Welcome to the Admin Panel" + contact + "...";
            }
        }
    }
}
