using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hospital
{
    class operations
    {
        public static int pid;
        public int rand_num()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public bool validate_urin(String text1,String text2,String text3,String text4,String text5,String text6,String text7)
        {
            if (!string.IsNullOrWhiteSpace(text1) & !string.IsNullOrWhiteSpace(text2) & !string.IsNullOrWhiteSpace(text3) & !string.IsNullOrWhiteSpace(text4) & !string.IsNullOrWhiteSpace(text5) & !string.IsNullOrWhiteSpace(text6) & !string.IsNullOrWhiteSpace(text7))
            {
                return true;
            }
            else
            {
                MessageBox.Show("All fields are mandatory");
                return false;
            }
        }

        public bool validate_hema(String text1, String text2, String text3, String text4)
        {
            if (!string.IsNullOrWhiteSpace(text1) & !string.IsNullOrWhiteSpace(text2) & !string.IsNullOrWhiteSpace(text3) & !string.IsNullOrWhiteSpace(text4))
            {
                return true;
            }
            else
            {
                MessageBox.Show("All fields are mandatory");
                return false;
            }
        }

        public bool validate_echo(String text1, String text2, String text3)
        {
            if (!string.IsNullOrWhiteSpace(text1) & !string.IsNullOrWhiteSpace(text2) & !string.IsNullOrWhiteSpace(text3))
            {
                Regex r = new Regex("^([0-9]{1,10})$");
                if(r.IsMatch(text1) & r.IsMatch(text2) & r.IsMatch(text3))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Only digits allowed !!!");
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("Field should not be empty");
                return false;
            }
        }

        public bool validate(String text1,String text2,String text3,String text4,String text5,String text6,String text7)
        {
            if (text1 != null)
            {
                Regex r = new Regex("^[a-zA-Z]*$");
                if (r.IsMatch(text1))
                {
                   if (text2 != null)
                        {
                            Regex r1 = new Regex("^[a-zA-Z]*$");
                            if (r1.IsMatch(text2))
                            {
                                if (text3 != null)
                                {
                                    Regex r2 = new Regex("^([0-9]{10})$");
                                    if (r2.IsMatch(text3.ToString()))
                                    {

                                        if (text4 != null)
                                        {
                                            Regex r3 = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
                                            if (r3.IsMatch(text4))
                                            {

                                                if (text5 != null)
                                                {
                                                    Regex r4 = new Regex("^([0-9]{1,3})$");
                                                    if (r4.IsMatch(text5.ToString()))
                                                    {
                                                        if (text6 != null)
                                                        {
                                                            Regex r5 = new Regex("^[a-zA-Z]*$");
                                                            if (r5.IsMatch(text2))
                                                            {
                                                                if (text7 != null)
                                                                {
                                                                    Regex r6 = new Regex("^([0-9]){6,9}$");
                                                                    if (r6.IsMatch(text7.ToString()))
                                                                    {
                                                                        return true;
                                                                    }

                                                                    else
                                                                    {
                                                                        MessageBox.Show("Invalid Pin Code!!! Only digits allowed !!!");
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Field should not be empty");
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Invalid City !!! Numeric value not allowed!!!");
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Field should not be empty");
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Invalid Age !!! Only digits allowed !!!");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Field should not be empty");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Email Id is invalid !!!");
                                                return false;
                                            }
                                         
                                        }
                                        else
                                        {
                                            MessageBox.Show("Field should not be empty");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Phone number !!!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Field should not be empty");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Last name !!! No numeric value allowed !!!");
                                return false;

                            }
                        }
                   else
                   {
                       MessageBox.Show("Field should not be empty");
                       return false;
                   }
                }
                else
                {
                    MessageBox.Show("Invallid First Name !!! No numeric value allowed !!!");
                    return false;

                }

            }           
            else
            {
                MessageBox.Show("hello1");
                return false;
            }
        }

        public String report_hemo()
        {
            DBOperation db = new DBOperation();
            db.open_con();
            String qry = "select p.first_name,p.last_name,h.date,h.wbc,h.rbc,h.hgb,h.platelet from hematology h,patient p where p.code=h.code and p.code="+operations.pid;
            SqlCommand cmd = new SqlCommand(qry,db.con);
            SqlDataReader dr = cmd.ExecuteReader();
            String res = "";
            res += "---------------------------- Hematology report------------------- \n\n\n ";
            res += "CODE : ";
            res += operations.pid;
            while(dr.Read())
            {
                res += "\n -----------------------------\n";
                res += "Name  :";
                res += dr["first_name"] + " " + dr["last_name"] + "\n";
                var date = dr["date"];
                DateTime d = Convert.ToDateTime(date);
                var f = d.ToString("MM/dd/yyyy");
                res += "DATE  : ";
                res += f + "\n";
                res += "WBC  : ";
                res += dr["wbc"] + "\n";
                res += "RBC  : ";
                res += dr["rbc"] + "\n";
                res += "HGB  : ";
                res += dr["hgb"] + "\n";
                res += "PLATELET COUNT  : ";
                res += dr["platelet"] + "\n";
                res += "-----------------------------\n\n\n\n";
            }
            res += "                                   Authorize Signature\n\n\n\n\n\n";
            dr.Close();
            db.close_con();
            return res;
        }



        public String report_urin()
        {
            DBOperation db = new DBOperation();
            db.open_con();
            String qry = "select p.first_name,p.last_name,u.date,u.color,u.appearence,u.ph,u.specific_gravity,u.urobilinogen,u.wbc,u.rbc from urin u,patient p where p.code=u.code and u.code=" + operations.pid;
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader dr = cmd.ExecuteReader();
            String res = "";
            res += "---------------------------- Urin Test Report------------------- \n\n\n ";
            res += "CODE : ";
            res += operations.pid;
            while (dr.Read())
            {
                res += "\n -----------------------------\n";
                res += "Name  :";
                res += dr["first_name"] + " " + dr["last_name"] + "\n";
                var date = dr["date"];
                DateTime d = Convert.ToDateTime(date);
                var f = d.ToString("MM/dd/yyyy");
                res += "DATE  : ";
                res += f + "\n";
                res += "urin Color  : ";
                res += dr["color"] + "\n";
                res += "Appearance  : ";
                res += dr["appearence"] + "\n";
                res += "PH COUNT  : ";
                res += dr["ph"] + "\n";
                res += "Specific Gravity  : ";
                res += dr["specific_gravity"] + "\n";
                res += "Urobilinogen  : ";
                res += dr["urobilinogen"] + "\n";
                res += "RBC COUNT : ";
                res += dr["rbc"] + "\n";
                res += "WBC COUNT  : ";
                res += dr["wbc"] + "\n";
                res += "-----------------------------\n\n\n\n";
            }
            res += "                                     Authorize Signature\n\n\n\n\n\n";
            dr.Close();
            db.close_con();
            return res;
        }



        public String report_echo()
        {
            DBOperation db = new DBOperation();
            DateTime ef;
            db.open_con();
            String qry = "select p.first_name,p.last_name,e.date,e.Ao_Diam,e.Lvot_Diam,e.LA_Diam from Echo e,patient p where p.code=e.code and e.code=" + operations.pid;
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader dr = cmd.ExecuteReader();
            String res = "";
            res += "---------------------------- Echocardiogram Report------------------- \n\n\n ";
            res += "CODE : ";
            res += operations.pid;
            while (dr.Read())
            {
                res += "\n -----------------------------\n";
                res += "Name  :";
                res += dr["first_name"] + " " + dr["last_name"] + "\n";
                res += "DATE  : ";
                var date = dr["date"];
                DateTime d = Convert.ToDateTime(date);
                var f = d.ToString("MM/dd/yyyy");
                
                res += f + "\n";
                res += "Ao_Diameter  : ";
                res += dr["Ao_Diam"] + "\n";
                res += "Lvot_Diameter  : ";
                res += dr["Lvot_Diam"] + "\n";
                res += "LA_Diam  : ";
                res += dr["LA_Diam"] + "\n";
                
                res += "-----------------------------\n\n\n\n";
            }
            res += "                                  Authorize Signature\n\n\n\n\n\n";
            dr.Close();
            db.close_con();
            return res;
        }

    }
}
