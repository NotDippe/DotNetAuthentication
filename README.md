# DotNetAuthentication
a simple .net open source authentication library

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
