﻿using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace AliaksNad.Battleship.IdentityServer3.SelfHost.Config
{
    static class Certificate
    {
        public static X509Certificate2 Get()
        {
            //return new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\idsrv3test.pfx"), "idsrv3test");

            var assembly = typeof(Certificate).Assembly;
            using (var stream = assembly.GetManifestResourceStream("AliaksNad.Battleship.IdentityServer3.SelfHost.Config.idsrv3test.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}