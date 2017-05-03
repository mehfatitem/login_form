using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace LoginForm{
    class Database{
        //server , database , username , password name for the db connection
        private String server = "";
        private String database = "";
        private String user = "";
        private String password = "";

        //conenction object
        private static MySqlConnection conn;

        //open the db conneciton
        public void openConn(){
            //create the connection and start it
            using (System.IO.StreamReader r = new System.IO.StreamReader("json_data/db_info.json",Encoding.GetEncoding("iso-8859-9"), false)){
                string json = r.ReadToEnd();
                Db items = JsonConvert.DeserializeObject<Db>(json);
                this.server = items.server;
                this.database = items.databasename;
                this.password = items.password;
                this.user = items.username;
            }
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd="+password+";charset=utf8"); 
            conn.Open();
        }

        //close the db connection
        public void closeConn(){
             conn.Close();
        } 

        //login control method
        public String loginOperation(String userName, String pass , String language,Form form){
            String returnMessage = "";
            this.openConn();
            String sql = "Select * from user_tbl where username = '" +userName+ "' and password = '" +pass+ "'";
            MySqlCommand command = new MySqlCommand(sql , conn);
            MySqlDataReader my_reader;
            my_reader = command.ExecuteReader();
            int count = 0;
            while (my_reader.Read()){
                count = count + 1;
            }
            if (count  == 1){//if login operation is success , go to admin panel...
                AdminPanel panel = new AdminPanel();
                form.Hide();
                panel.Show();
            }
            else{
                if (language == "Türkçe")
                    returnMessage = "\nKullanıcı adı veya şifreniz yanlış !\n";
                else
                    returnMessage = "\nInvalid username or password !\n";
            }
            this.closeConn();
            return returnMessage;
        }

        //get the user full name
        public String getContact(String userName){
            String contact = "";
            this.openConn();
            String sql = "Select contact from user_tbl where username = '" + userName + "'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader my_reader;
            my_reader = command.ExecuteReader();
            while (my_reader.Read()){
                contact = my_reader.GetValue(1).ToString();
            }
            return contact;
        }
        public class Db{
            public String server;
            public String username;
            public String password;
            public String databasename;

            public String Server{
                get{return server;}
                set { server = value; }
            }
            public String Username{
                get { return username; }
                set { username = value; }
            }
            public String Password{
                get { return password; }
                set { password = value; }
            }
            public String Databasename{
                get { return databasename; }
                set { databasename = value; }
            }

        }

    }
}
