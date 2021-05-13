# Server-Client-Communication-WCF
CoreWCF on DotNet 5.0 called from a WCF .net framework 4.7.2 with nettcp streaming

Testing out [CoreWCF/CoreWCF](https://github.com/CoreWCF/CoreWCF) to see how easy it is to move .net framework WCF services that use net.tcp to .net 5.0. 

From what I see, this first release of CoreWCF gives all the basic functionality required for porting. In case you use it, security/encryption should be looked at. 

Running under linux with netTcpBinding security activated requires a AD server for me to join, which I don't have setup. It seems the setps would be similar to [this explanation](https://docs.microsoft.com/en-us/sql/azure-data-studio/enable-kerberos?view=sql-server-2017#join-your-os-to-the-active-directory-domain-controller). I'd have to setup a whole environment to test that out. 

| Feature  | Status   | Note |
|----------|----------| -----|
| CoreWCF  | Working  | Runs services OK     |
| net.Tcp Streaming | Working  | OK   |
| net.Tcp on windows | Working  | binding.Security.Mode = SecurityMode.Transport    |
| net.Tcp on linux | Working  |  binding.Security.Mode = SecurityMode.None   |
| net.Tcp on linux SecurityMode.Transport | No  |  Need a domain join  |
