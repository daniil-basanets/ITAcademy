﻿using System;
using System.Collections.Generic;
using System.Text;
using EnvelopeAnalyzer.Models;
using Helpers;

namespace EnvelopeAnalyzer
{
    static class InputMenu
    {
        private static bool IsUserChoiceYes()
        {
            var s = Console.ReadLine();
            s = s.ToLower();
            return s.Contains('y') || s.Contains("yes");
        }

        private static CommonEnvelope GetEnvelopeFromArgs(string[] args)
        {
            float width;
            float height;
            ErrorCode errorCode;

            errorCode = Parser.TryGetFloat(args, 0, out width);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            errorCode = Parser.TryGetFloat(args, 1, out height);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            CommonEnvelope envelope = new Implementation.Rectangular(width, height);

            return envelope;
        }

        public static void Start(string[] args)
        {
            CommonEnvelope firstEnvelope = GetEnvelopeFromArgs(args);
            CommonEnvelope secondEnvelope = null;

            do
            {
                if (firstEnvelope == null)
                {
                    firstEnvelope = AskInputNewEnvelope("first");
                }

                secondEnvelope = AskInputNewEnvelope("second");

                if (firstEnvelope.IsEnoughSpaceFor(secondEnvelope))
                {
                    firstEnvelope.InnerItem = secondEnvelope;
                    Console.WriteLine("\r\nThe second envelope fits into the first envelope\r\n");
                }
                else if (secondEnvelope.IsEnoughSpaceFor(firstEnvelope))
                {
                    secondEnvelope.InnerItem = firstEnvelope;
                    Console.WriteLine("\r\nThe first envelope fits into the second envelope\r\n");
                }
                else
                {
                    Console.WriteLine("\r\nThe envelopes do not fit each other!\r\n");
                }
                

                firstEnvelope = null;
                secondEnvelope = null;
            } while (AskInputContinue());
        }

        public static bool AskInputContinue()
        {
            Console.WriteLine("Do you want to continue? Type \"y\" or \"yes\"");
            var b = IsUserChoiceYes();
            Console.WriteLine(("").PadRight(24, '-'));
            return b;
        }

        public static CommonEnvelope AskInputNewEnvelope(string envelopeName = "")
        {
            float width;
            float height;
            string s;
            ErrorCode errorCode;

            Console.WriteLine("\r\nPlease, set {0} Envelope`s", envelopeName);
            Console.Write("width: ");
            s = Console.ReadLine();
            errorCode = Parser.TryGetFloat(s, out width);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());
            }

            Console.Write("height: ");
            s = Console.ReadLine();
            errorCode = Parser.TryGetFloat(s, out height);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());
            }

            CommonEnvelope envelope = new EnvelopeAnalyzer.Implementation.Rectangular(width, height);

            return envelope;
        }
    }
}