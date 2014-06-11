using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LoanMac.Core
{
    public class Utility
    {
        private static string EncryptionKey = "MAKV2SPBNI99212";

        public static string EncryptQueryString(string clearText)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string DecryptQueryString(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static bool EmailValidator(string email)
        {

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool DateValidator(string date)
        {

            DateTime dateTime2;
            if (DateTime.TryParse(date, out dateTime2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool NumberValidator(string num)
        {

            int int2;
            if (int.TryParse(num, out int2) && int2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DecimalValidator(string num)
        {

            decimal int2;
            if (decimal.TryParse(num, out int2) && int2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PictureValidator(string filename)
        {

            string pattern = @"([^\s]+(\.(?i)(jpg|png|gif|bmp))$)";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(filename);
        }


        public static DataView FilterDataTable(DataTable dt, string filterstring)
        {
            DataTable retVal = new DataTable();
            dt.DefaultView.RowFilter = filterstring;
            return dt.DefaultView;

        }

        public static int GetColumnID(string columnName, GridView grd)
        {

            foreach (DataControlField column in grd.Columns)
            {
                if ((column.HeaderText.ToUpper() == columnName.ToUpper()))
                {
                    int columnID = grd.Columns.IndexOf(column);
                    return columnID;
                }
            }

            return 0;
        }

        public static string FormalFormat(string inString)
        {
            string outString = string.Empty;
            string _ErrorMessage = string.Empty;
            try
            {
                // Formal Format is made for names and addresses to assure 
                // proper formatting and capitalization
                if (string.IsNullOrEmpty(inString))
                {
                    return string.Empty;
                }
                inString = inString.Trim();
                if (string.IsNullOrEmpty(inString))
                {
                    return string.Empty;
                }
                // see if this is a word or a series of words
                //if(inString.IndexOf(" ") > 0)
                //{
                // Break out each word in the string. 
                char[] charSep = { ' ' };
                string[] aWords = inString.Split(charSep);
                int i = 0;
                int CapAfterHyphen = 0;
                for (i = 0; i < aWords.Length; i++)
                {

                    string Word = aWords[i].Trim();
                    CapAfterHyphen = Word.IndexOf("-");
                    char[] chars = Word.ToCharArray();
                    if (chars.Length > 3)
                    {
                        if (Char.IsLower(chars[1]) && Char.IsUpper(chars[2]))
                        {
                            Word = Word.Substring(0, 1).ToUpper() + Word.Substring(1, 1).ToLower() + Word.Substring(2, 1).ToUpper() + Word.Substring(3).ToLower();
                        }
                        else
                        {
                            Word = Word.Substring(0, 1).ToUpper() + Word.Substring(1).ToLower();
                        }
                    }
                    if (CapAfterHyphen > 0)
                    {
                        Word = Word.Substring(0, CapAfterHyphen + 1) + Word.Substring(CapAfterHyphen + 1, 1).ToUpper() + Word.Substring(CapAfterHyphen + 2);
                    }
                    if (i > 0)
                    {
                        outString += " " + Word;
                    }
                    else
                    {
                        outString = Word;
                    }
                }
            }
            catch (Exception e)
            {
                outString = inString;
                _ErrorMessage = e.Message;
            }
            return outString;
        }

        public static void Send(string Subject, string Body, string To, bool BodyHTML)
        {
            try
            {
                MailMessage mail = new MailMessage();
                
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = BodyHTML;
                mail.From = new MailAddress("postmaster@moneyloandering.com");
                mail.To.Add(new MailAddress(To));

                SmtpClient client = new SmtpClient();
                //client.Host = "mail.moneyloandering.com";
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }

            
        }
    }
}
