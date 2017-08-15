using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MultipleChoice
{
    public partial class Register : Form
    {
        //creating a stream reader variable.
        StreamWriter write;
        public Register()
        {
            InitializeComponent();
      
        }
        //register onlick button
        private void lblRegister_Click(object sender, EventArgs e)
        {
            //method call
            registerButton(); 
        }


        private void txtDateOF_MouseEnter(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "Day / Month / Year") 
            {
                txtDateOF.Text = "";
            }
        }

        private void txtDateOF_MouseLeave(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "")
            {
                txtDateOF.Text = "Day / Month / Year";
            }
        }

        private void txtEmailAddress_MouseEnter(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "someone@example.com")
            {
                txtEmailAddress.Text = "";
            }
        }

        private void txtEmailAddress_MouseLeave(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "someone@example.com";
                
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //method call
            registerButton();
        }

        public void registerButton() 
        {
            //try and catch to open the file and write to it and close it.
            try
            {
                string students =
                    txtUsername.Text.ToLower() + "," +
                    txtPassword.Text + "," +
                    txtFirstName.Text + "," +
                    txtLastName.Text + "," +
                    txtDateOF.Text + "," +
                    txtEmailAddress.Text.ToLower() + "\n";
                //creating the file.
                write = new StreamWriter("studentDetails.txt", true);

                //if statements to filter the inputs. 
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtDateOF.Text != "" && txtEmailAddress.Text != "")
                {
                    if (txtDateOF.Text != "Day / Month / Year" && txtEmailAddress.Text != "someone@example.com")
                    {
                        if (txtEmailAddress.Text.Contains("@") && txtEmailAddress.Text.Contains(".com"))
                        {
                            write.Write(students);
                            //displaying to the user that registration was successful.
                            MessageBox.Show("Registration was sucessful", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtFirstName.Clear();
                            txtLastName.Clear();
                            txtDateOF.Clear();
                            txtDateOF.Text = "Day / Month / Year";
                            txtEmailAddress.Clear();
                            txtEmailAddress.Text = "someone@example.com";
                        }
                        else
                        {
                            MessageBox.Show("Your email format is not correct please enter correct email \n e.g someone@example.com", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //catching all exceptions
            catch (System.IO.PathTooLongException path)
            {
                MessageBox.Show(path.Message);

            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing my file.
                write.Close();
            }
        }

     
    }
}
