# DotNetAuthentication
a simple .NET open source authentication library with AES encryption and post request.

# Example Of Program
```C#
using System;

namespace DotNetAuthentication {
    class Program {
        static void Main( string [ ] args ) {
            try {
                if ( authentication.Auth.AuthenticationCheck( ) )
                    Console.WriteLine( "Whitelisted" );
            } 
            catch { Console.WriteLine( "You aren't whitelisted" ); }
            Console.ReadLine( );
        }
    }
}
```
thanks to https://github.com/Lypd-cs/DotNetSimpleAuth for the base
