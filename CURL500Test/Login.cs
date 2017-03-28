using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CURL500Test
{
    public partial class Login : Form
    {
        private PTStransaction pts;
        public Operator oper { get; set; }
        public TestSet testSet { get; set; }
        private ErrorProvider passwordErrorProvider;
        private ErrorProvider usernameErrorProvider;

        public Login(Operator oper, TestSet tset)
        {
            pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            this.oper = oper;
            passwordErrorProvider = new ErrorProvider();
            usernameErrorProvider = new ErrorProvider();
            testSet = tset;
            InitializeComponent();
            ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            oper.Id = username.Text.ToUpper();
            oper.password = password.Text.ToUpper();
            List<string> PTSresponse;
            PTSresponse = pts.loginOperator(oper, testSet).ToList();

            //PTS RETURN: 31:EGG400:12:158:RE:OP:0:JCB158:BROWN JERRY C:
            if (PTSresponse[(int)PTSField.RESPONSE_STATUS] == "0")
            {
                oper.loggedIn = true;
                testSet.oper = oper;
                this.Close();
            }
            else
            {
                loginStatusLabel.Text = PTSresponse[(int)PTSField.RESPONSE_STATUS + 2];
                password.SelectAll();
            }
            oper.name = PTSresponse[(int)PTSField.RESPONSE_STATUS + 2];
        }

        private void username_Validating(object sender, CancelEventArgs e)
        {
            string error;
            if (!validUserId(username.Text, out error))
            {
                //cancel the event and select the name so it can be corrected
                e.Cancel = true;
                username.Select(0, username.Text.Length);

                //set the errorprovider with the error text
                usernameErrorProvider.SetError(username, error);
            }
        }

        public bool validUserId(string username, out string errorMessage)
        {
            if (username.Length != 3)
            {
                errorMessage = "Operator ID must be 3 characters";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        private void username_Validated(object sender, EventArgs e)
        {
            usernameErrorProvider.SetError(username, "");
            oper.Id = username.Text.ToUpper();
        }

        private void password_Validating(object sender, CancelEventArgs e)
        {
            string error;
            if (!validPassword(password.Text, out error))
            {
                //cancel the event and select the name so it can be corrected
                e.Cancel = true;
                password.Select(0, password.Text.Length);

                //set the errorprovider with the error text
                passwordErrorProvider.SetError(password, error);
            }
        }

        private bool validPassword(string text, out string errorMessage)
        {
            if (password.Text.Length < 6)
            {
                errorMessage = "Password must be at least 6 characters";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        private void password_Validated(object sender, EventArgs e)
        {
            passwordErrorProvider.SetError(password, "");
            oper.password = password.Text.ToUpper();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void OnPTSMessageSending(object source, EventArgs args)
        {
            loginStatusLabel.Text = "Logging you in";
        }
    }
}
