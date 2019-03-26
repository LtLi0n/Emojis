﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoSmart.Unicode
{
    //We hereby declare emoji to be a zero plural marker noun (in short, "emoji" is both the singular and the plural form)
    //this class refers to emoji in the singular
    public struct SingleEmoji : IEqualityComparer<SingleEmoji>, IComparable<SingleEmoji>, IEquatable<SingleEmoji>
    {
        static readonly string[] NoTerms = new string[] { };
        public readonly UnicodeSequence Sequence;
        public readonly string Name;
        public readonly string[] SearchTerms;
        public readonly int SortOrder;
        public readonly string Group;
        public readonly string Subgroup;

        public SingleEmoji(UnicodeSequence sequence, string name = "", string[] searchTerms = null, int sortOrder = -1, string group = "", string subgroup = "")
        {
            Sequence = sequence;
            Name = name;
            SearchTerms = searchTerms ?? NoTerms;
            SortOrder = sortOrder;
            Group = group;
            Subgroup = subgroup;
        }

        public int CompareTo(SingleEmoji other)
        {
            return Sequence.CompareTo(other.Sequence);
        }

        public bool Equals(SingleEmoji a, SingleEmoji b)
        {
            return a.Sequence.Equals(b.Sequence);
        }

        public int GetHashCode(SingleEmoji obj)
        {
            return obj.GetHashCode();
        }

        public static bool operator ==(SingleEmoji a, SingleEmoji b)
        {
            return a.Sequence == b.Sequence;
        }

        public static bool operator !=(SingleEmoji a, SingleEmoji b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is SingleEmoji emoji)
            {
                return Equals(this, emoji);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Sequence.GetHashCode();
        }

        public override string ToString()
        {
            return Encoding.Unicode.GetString(Sequence.AsUtf16Bytes().ToArray());
        }

        public bool Equals(SingleEmoji other)
        {
            return Equals(this, other);
        }
    }
}
