﻿using System;
using System.Collections.Generic;
using JWLibrary.Core;
using NUnit.Framework;

namespace JWLibrary.NUnit.Test {
    public class JDictionaryUtilTest {
        [Test]
        public void JConcatTest() {
            IDictionary<string, string> mapA = new Dictionary<string, string>();
            mapA.Add("A", "A");
            mapA.Add("B", "");
            IDictionary<string, string> mapB = new Dictionary<string, string>();
            mapB.Add("B", "BB");
            mapB.Add("C", "C");

            //if exists same key, throw error 
            //var result = mapA.jConcat(mapB);
            //Assert.AreEqual(result["C"], "C");

            //if exists same key, update second value.
            var result2 = mapA.jConcatUpdate(mapB);
            Assert.AreEqual(result2["B"], "BB");

            Console.WriteLine(result2.jObjectToJson());
        }

        [Test]
        public void JDictionaryPoolTest() {
            JDictionaryPool<string, string> jDictionaryPool = new JDictionaryPool<string, string>();
            jDictionaryPool.Add("A", "A");
            jDictionaryPool.Add("B", "B");
            jDictionaryPool.Add("C", "C");

            // Assert.AreEqual(jDictionaryPool.GetValue("A"), "A");

            IDictionary<string, string> copy = jDictionaryPool.ToDictionary();
            Assert.AreEqual(copy["A"], "A");
            copy["A"] = "AA";
            Assert.AreEqual(jDictionaryPool.GetValue("A"), "A");
            Assert.AreEqual(copy["A"], "AA");

            jDictionaryPool.Release("C", "C");
            jDictionaryPool.Clear();
            
            Console.WriteLine(jDictionaryPool.jObjectToJson());
            
        }
    }
}