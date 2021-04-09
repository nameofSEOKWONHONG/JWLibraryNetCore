﻿using System;
using System.Linq;

namespace JWLibrary.Core {
    public static class JReflection {
        public static TValue getAttrValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (att.isNotNull()) return valueSelector(att);
            return default;
        }
    }
}