﻿using GRBL;
using GRDL;
using GRDL.Entities;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Context
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            string connectionString = configuration.GetConnectionString("RecordDB");
            DbContextOptions<GRdatabaseContext> options = new DbContextOptionsBuilder<GRdatabaseContext>()
            .UseSqlServer(connectionString).Options;

            using var context = new GRdatabaseContext(options);
            //End context

            IMenu menu = new MainMenu(new RecordBL(new RecordRepoDB(context, new Mapper())),new CustomerBL(new CustomerRepoDB(context, new Mapper())));
            menu.Start();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(new CompactJsonFormatter(), "./Logs/logs.json")
                .CreateLogger();
                Log.Information("Successfully ran project.");
        }
    }
}
