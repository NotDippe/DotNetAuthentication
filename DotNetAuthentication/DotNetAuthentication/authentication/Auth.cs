using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace authentication {

    internal class Auth {
        public static string hwid = WindowsIdentity.GetCurrent( ).User.Value;
        public static string Password = "php password"; //this value should be the same as on php file in encrypt / decrypt value.
        public static string SessionID = GenerateRandomString( );
        public static string link = "yourlink.com/api.php";
        public static bool AuthenticationCheck( ) {
            SHA256 mySHA256 = SHA256.Create( );
            byte [ ] key = mySHA256.ComputeHash( Encoding.ASCII.GetBytes( Password ) );
            byte [ ] iv = new byte [ 16 ] { 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 };
            var values = new NameValueCollection {
                [ "request" ] = AesEncrypt.EncryptString( hwid , key , iv ) ,
                [ "session" ] = AesEncrypt.EncryptString( SessionID , key , iv ) ,
            };
            string requestt = Encoding.Default.GetString( new WebClient( ).UploadValues( link , values ) );
            if ( requestt.Contains( AesEncrypt.EncryptString( "Whitelisted" + SessionID , key , iv ) ) )
                return true;
            return false;
        }
        public static string GenerateRandomString( int length = 35 ) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random( );
            var randomString = new string( Enumerable.Repeat( chars , length ).Select( s => s [ random.Next( s.Length ) ] ).ToArray( ) );
            return randomString;
        }
    }
}
