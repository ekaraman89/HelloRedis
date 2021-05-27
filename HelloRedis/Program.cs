﻿using StackExchange.Redis;
using System;

namespace HelloRedis
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 16; i < 55; i++)
            {
                Random rnd = new Random();
                SaveData($"key{i}", rnd.Next(100).ToString());
            }
            Console.Write("Yazma Islemi Tamamlandi\nOkumaya basliyor\n");
            for (int i = 16; i < 55; i++)
            {
                Random rnd = new Random();
                var s = ReadData($"key{i}");
                Console.WriteLine(s);
            }
        }

        private static void SaveData(string key, string value)
        {
            var options = ConfigurationOptions.Parse("localhost:6379");
            options.Password = "tt";
            ConnectionMultiplexer redisCon = ConnectionMultiplexer.Connect(options);
            IDatabase conn = redisCon.GetDatabase();
            conn.StringSet(key, value);
        }

        private static string ReadData(string key)
        {
            var options = ConfigurationOptions.Parse("localhost:6379");
            options.Password = "tt";
            ConnectionMultiplexer redisCon = ConnectionMultiplexer.Connect(options);
            IDatabase conn = redisCon.GetDatabase();
            return conn.StringGet(key);
        }
    }
}