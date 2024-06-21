using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DALayer
{
    public class DAL
    {
        public static void Insert_Registration_Info(Database db, string FName, string LName, string Email, long Pnumber, string Password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO LDB1_USERINFORMATION(FFIRSTNAME, FLASTNAME, FEMAIL, FMOBILE, FPASSWORD) VALUES (@FIRSTNAME,@LASTNAME,@EMAIL,@MOBILE,@PASSWORD)");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@FIRSTNAME", DbType.AnsiString, FName);
            db.AddInParameter(dbCommand, "@LASTNAME", DbType.AnsiString, LName);
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, Email);
            db.AddInParameter(dbCommand, "@MOBILE", DbType.Int64, Pnumber);
            db.AddInParameter(dbCommand, "@PASSWORD", DbType.AnsiString, Password);
            db.ExecuteNonQuery(dbCommand);
        }
        public static DataTable LoadGridView(Database db)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT FID,FFIRSTNAME, FEMAIL,FPASSWORD, FUSERROLEID FROM LDB1_UserInformation");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            DataTable dtbl = db.ExecuteDataSet(dbCommand).Tables[0];
            return dtbl;
        }
        public static int Get_Login_Details(Database db, string email, string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT LDB1_ROLE.FROLEID FROM LDB1_ROLE INNER JOIN LDB1_USERINFORMATION WHERE LDB1_USERINFORMATION.FEMAIL=@EMAIL AND LDB1_USERINFORMATION.FPASSWORD=@PASSWORD AND LDB1_ROLE.FROLEID=LDB1_USERINFORMATION.FUSERROLEID");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, email);
            db.AddInParameter(dbCommand, "@PASSWORD", DbType.AnsiString, password);
            dbCommand.CommandType = CommandType.Text;
            int obj = (int)db.ExecuteScalar(dbCommand);
            return obj;
        }
        public static void Insert_User_Info(Database db, string fName, string lName, string email, int roleId, string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO LDB1_USERINFORMATION(FFIRSTNAME, FLASTNAME, FEMAIL, FUSERROLEID,FPASSWORD) VALUES (@FIRSTNAME,@LASTNAME,@EMAIL,@ROLEID,@PASSWORD)");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@FIRSTNAME", DbType.AnsiString, fName);
            db.AddInParameter(dbCommand, "@LASTNAME", DbType.AnsiString, lName);
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, email);
            db.AddInParameter(dbCommand, "@ROLEID", DbType.Int32, roleId);
            db.AddInParameter(dbCommand, "@PASSWORD", DbType.AnsiString, password);
            db.ExecuteNonQuery(dbCommand);
        }

        public static void Update_User_Info(Database db, int userId, int roleId, string fName, string email, string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE LDB1_USERINFORMATION SET FFIRSTNAME=@USERNAME, FEMAIL=@USEREMAIL,FUSERROLEID=@USERROLEID, FPASSWORD=@USERPASSWORD WHERE FID=@FUID");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@USERNAME", DbType.AnsiString, fName);
            db.AddInParameter(dbCommand, "@USEREMAIL", DbType.AnsiString, email);
            db.AddInParameter(dbCommand, "@USERROLEID", DbType.Int32, roleId);
            db.AddInParameter(dbCommand, "@USERPASSWORD", DbType.AnsiString, password);
            db.AddInParameter(dbCommand, "@FUID", DbType.Int32, userId);
            db.ExecuteNonQuery(dbCommand);
        }

        public static int GetUserId(Database db, string email, string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT LDB1_USERINFORMATION.FID FROM LDB1_USERINFORMATION WHERE LDB1_USERINFORMATION.FEMAIL=@EMAIL AND LDB1_USERINFORMATION.FPASSWORD=@PASSWORD");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, email);
            db.AddInParameter(dbCommand, "@PASSWORD", DbType.AnsiString, password);
            dbCommand.CommandType = CommandType.Text;
            int obj = (int)db.ExecuteScalar(dbCommand);
            return obj;
        }
        public static DataTable GetUserProfileDetails(Database db, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM LDB1_USERINFORMATION INNER JOIN LDB1_ROLE WHERE LDB1_USERINFORMATION.FID=@ID AND LDB1_USERINFORMATION.FUSERROLEID=LDB1_ROLE.FROLEID");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            db.AddInParameter(dbCommand, "@ID", DbType.Int32, id);
            dbCommand.CommandType = CommandType.Text;
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        public static void DeleteUserRow(Database db, int userId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM LDB1_USERINFORMATION WHERE FID=@ID");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ID", DbType.Int32, userId);
            db.ExecuteNonQuery(dbCommand);
        }
        public static void UpdateUserProfileDetails(Database db, string email, string password, char gender, long pNumber, string country, string state, string city, string address, string pinCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE LDB1_USERINFORMATION SET FGENDER=@GENDER, FMOBILE=@MOBILE,FCOUNTRY=@COUNTRY, FSTATE=@STATE, FCITY=@CITY, FADDRESS=@ADDRESS, FPINCODE=@PINCODE WHERE FEMAIL=@EMAIL AND FPASSWORD=@PASSWORD");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, email);
            db.AddInParameter(dbCommand, "@PASSWORD", DbType.AnsiString, password);
            db.AddInParameter(dbCommand, "@GENDER", DbType.StringFixedLength, gender);
            db.AddInParameter(dbCommand, "@MOBILE", DbType.Int64, pNumber);
            db.AddInParameter(dbCommand, "@COUNTRY", DbType.AnsiString, country);
            db.AddInParameter(dbCommand, "@STATE", DbType.AnsiString, state);
            db.AddInParameter(dbCommand, "@CITY", DbType.AnsiString, city);
            db.AddInParameter(dbCommand, "@ADDRESS", DbType.AnsiString, address);
            db.AddInParameter(dbCommand, "@PINCODE", DbType.AnsiString, pinCode);
            db.ExecuteNonQuery(dbCommand);
        }

        public static string GetAlreadyRegisteredInfo(Database db, String Email)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT LDB1_USERINFORMATION.FEMAIL,LDB1_USERINFORMATION.FMOBILE FROM LDB1_USERINFORMATION WHERE FEMAIL=@EMAIL");
            DbCommand dbCommand = db.GetSqlStringCommand(stringBuilder.ToString());
            db.AddInParameter(dbCommand, "@EMAIL", DbType.AnsiString, Email);
            dbCommand.CommandType = CommandType.Text;
            string obj = (string)db.ExecuteScalar(dbCommand);
            return obj;
        }
    }
}