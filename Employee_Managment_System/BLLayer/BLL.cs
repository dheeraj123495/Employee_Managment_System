﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DALayer;


namespace BLLayer
{
    public class BLL
    {
        public static string InsertInfoToTable(string FName, string LName, string Email, long Pnumber, string Password)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    string dt = DAL.GetAlreadyRegisteredInfo(db, Email);
                    if (dt == null)
                    {
                        DAL.Insert_Registration_Info(db, FName, LName, Email, Pnumber, Password);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                    return "Exception Occured";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //This method is used to fetch the details of the all the available users.
        public static DataTable LoadDatailsForGridView()
        {
            DataTable dt = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    dt = DAL.LoadGridView(db);
                    return dt;
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                    return dt;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //This method will fetch the roleid from the database and redirect the user to respective dashboard.
        public static int GetLoginDetailsFromTable(string email, string password)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    int getRoleId = DAL.Get_Login_Details(db, email, password);
                    return getRoleId;
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // This method will insert the user information to database, which is added by the admin through his dashboard.
        public static string InsertUserInfoToTable(string fName, string lName, string email, int roleId, string password)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    string st = DAL.GetAlreadyRegisteredInfo(db, email);
                    if (st == null)
                    {
                        DAL.Insert_User_Info(db, fName, lName, email, roleId, password);
                    }
                    return st;
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                    return "Exception Occured";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // This method is used to update the user info from the admin panel.
        public static string UpdateUserInfoToTable(int userId, int roleId, string fName, string email, string password)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    string st = DAL.GetAlreadyRegisteredInfo(db, email);
                    if (st == null)
                    {
                        DAL.Update_User_Info(db, userId, roleId, fName, email, password);
                    }
                    return st;
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                    return "Exception Occured";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //This method is used to display the user details in his profile when he will login.
        public static DataTable GetUserDetailsFromTable(string email, string password)
        {
            DataTable dt = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    int id = DAL.GetUserId(db, email, password);
                    if (id > 0)
                    {
                        dt = DAL.GetUserProfileDetails(db, id);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //This method is used to delete the user information in the admin panel.
        public static void DeleteUserRowFromTable(int userId)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    DAL.DeleteUserRow(db, userId);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        // This method is used to add and update the user info.
        public static void UpdateUserProfileDataToTable(string email, string password, char gender, long pNumber, string country, string state, string city, string address, string pinCode)
        {
            Database db = DatabaseFactory.CreateDatabase("connetionApplication");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                try
                {
                    DAL.UpdateUserProfileDetails(db, email, password, gender, pNumber, country, state, city, address, pinCode);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendErrorToText(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}